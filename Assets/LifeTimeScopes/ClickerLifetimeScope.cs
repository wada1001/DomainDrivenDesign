using App.EntryPoints;
using App.OutPuts;
using App.Presenters;
using App.Usecases;
using Domain.Repositories;
using Infra.Repositories;
using VContainer;
using VContainer.Unity;
using Views.Components;

namespace Container
{
    public class ClickerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            //RegisterDomain(builder);
            RegisterApp(builder);
            RegisterView(builder);
            RegisterInfra(builder);
        }

        protected void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<StateMachine>();
        }

        protected void RegisterApp(IContainerBuilder builder)
        {
            builder.Register<State, ClickerPresenter>(Lifetime.Scoped);
            builder.Register<State, ItemPresenter>(Lifetime.Scoped);

            builder.Register<ItemUsecase>(Lifetime.Singleton).As<IItemUsecase>();
        }

        //protected void RegisterDomain(IContainerBuilder builder)
        //{

        //}

        protected void RegisterInfra(IContainerBuilder builder)
        {
            builder.Register<GameSession>(Lifetime.Singleton).As<IGameSession>();
            builder.Register<ItemRepository>(Lifetime.Singleton).As<IItemRepository>();
        }

        protected void RegisterView(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ClickerView>().As<IClickerOutPut>();
            builder.RegisterComponentInHierarchy<ItemView>().As<IItemOutPut>();
            builder.RegisterComponentInHierarchy<DialogView>().As<IDialogOutPut>();
        }
    }
}