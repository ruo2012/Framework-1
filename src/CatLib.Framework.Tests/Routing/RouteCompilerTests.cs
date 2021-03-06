﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using CatLib.API.Routing;
using CatLib.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatLib.Tests.Routing
{
    [TestClass]
    public class RouteCompilerTests
    {
        /// <summary>
        /// 触发编译异常的测试
        /// </summary>
        [TestMethod]
        public void ThrowErrorCompilerTest()
        {
            var route = new Route(new Uri("catlib://hello/{10name}"), new RouteAction());
            ExceptionAssert.Throws<DomainException>(() =>
            {
                RouteCompiler.Compile(route);
            });

            route = new Route(new Uri("catlib://hello/{name}/{name}"), new RouteAction());
            ExceptionAssert.Throws<DomainException>(() =>
            {
                RouteCompiler.Compile(route);
            });

            route = new Route(new Uri("catlib://hello/{namejajskajskajskajskajskajskajskauqjsuqkqsuqjs}"), new RouteAction());
            ExceptionAssert.Throws<DomainException>(() =>
            {
                RouteCompiler.Compile(route);
            });
        }
    }
}
