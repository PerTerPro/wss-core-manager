using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Wss.Entities;
using Wss.Repository;


namespace Wss.Bll
{
    public interface IBlulkRunnerBasic
    {    
    }

    public abstract class BulkRunnerBasic
    {

        protected object objLockRun = new object();
        public abstract void Run();
        readonly CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        public ILog log = LogManager.GetLogger(typeof (BulkRunnerBasic));
        public abstract bool CheckRun();
      

        public void Start()
        {
            TaskFactory t = new TaskFactory(_cancellationToken.Token);

            t.StartNew(new Action(() =>
            {
                while (true)
                {
                    try
                    {
                        log.Debug("Start run check bulk");
                        if (CheckRun())
                        {
                            Run();
                        }
                        else
                        {
                            log.Debug("No need run");
                        }
                        Thread.Sleep(100);
                    }
                    catch (OperationCanceledException ex02)
                    {
                        log.Debug("Thread stop by user success");
                    }
                    catch (Exception ex01)
                    {
                        log.Error(ex01);
                    }
                    
                }
            }));
        }

        public void Stop()
        {
            _cancellationToken.Cancel();
        }
    }


    public class BulkHanderUpdateImgageId : BulkRunnerBasic
    {
        private readonly IProductRepository _productRepository;
        private  DateTime _lastRun = DateTime.Now;
        private readonly List<ImageProductInfo> _imageProductInfos=new List<ImageProductInfo>(); 

        public BulkHanderUpdateImgageId(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public override bool CheckRun()
        {
            lock (this.objLockRun)
            {
                return ((_lastRun - DateTime.Now).TotalMinutes > 5 || _imageProductInfos.Count() > 10);
            }
        }

        public override void Run()
        {
           
            lock (this.objLockRun)
            {
                _productRepository.UpdateImageBatch(_imageProductInfos);
                _imageProductInfos.Clear();
                _lastRun = DateTime.Now;
            }
          
        }

        public void AddItem(ImageProductInfo productInfo)
        {
            lock (this.objLockRun)
            {
                _imageProductInfos.Add(productInfo);
            } 
        }
    }
}
