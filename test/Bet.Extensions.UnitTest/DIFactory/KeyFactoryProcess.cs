﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using static Bet.Extensions.UnitTest.DIFactory.FactoryTests;

namespace Bet.Extensions.UnitTest.DIFactory
{
    public class KeyFactoryProcess
    {
        private readonly IKeyFactory<ProcessKey, IProcess> _factory;

        public KeyFactoryProcess(IKeyFactory<ProcessKey, IProcess> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void DoWork()
        {
            var instance = _factory.Create(ProcessKey.A);

            instance.Run();
        }
    }
}
