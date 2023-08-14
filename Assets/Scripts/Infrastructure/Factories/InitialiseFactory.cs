using Bindings;
using Drawing;
using GameControl.GamePlay;
using Zenject;

namespace Infrastructure.Factories
{
    public class InitialiseFactory
    {
        private readonly Drawer.Factory drawerFactory;
        private readonly IProperNumberOfElementsHandler.Factory properReachesHandler;
        private readonly IProperNumberOfElementsHandler.Factory properDrawnHandler;


        public InitialiseFactory(Drawer.Factory drawerFactory, 
            [Inject(Id = BootstrapInstaller.PROPER_DRAWN_HANDLER)] IProperNumberOfElementsHandler.Factory properDrawnHandler,
            [Inject(Id = BootstrapInstaller.PROPER_REACHED_HANDLER)] IProperNumberOfElementsHandler.Factory properReachesHandler)
        {
            this.drawerFactory = drawerFactory;
            this.properDrawnHandler = properDrawnHandler;
            this.properReachesHandler = properReachesHandler;
        }

        public Drawer CreateDrawer()
        {
            return drawerFactory.Create();
        }

        public IProperNumberOfElementsHandler CreateProperDrawnHandler()
        {
            return properDrawnHandler.Create();
        }

        public IProperNumberOfElementsHandler CtreateProperReachedHandler()
        {
            return properReachesHandler.Create();
        }
    }
}