﻿using Application.DomainEventHandlers;
using Application.Features.ProductFeature.Commands.CreateProduct;
using Autofac;
using FluentValidation;
using Infrastructure.Infrastructure;
using MediatR;
using System.Reflection;

namespace MarketingTask.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateDistributorEventHandler)
                    .GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder.RegisterAssemblyTypes(typeof(CreateProductCommand).GetTypeInfo().Assembly)
              .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder
             .RegisterAssemblyTypes(typeof(CreateProductCommandValidator).GetTypeInfo().Assembly)
             .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
             .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
