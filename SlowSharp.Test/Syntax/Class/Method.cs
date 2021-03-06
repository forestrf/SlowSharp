﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Slowsharp.Test
{
    [TestClass]
    public class MethodTest
    {
        [TestMethod]
        public void BasicMethod()
        {
            Assert.AreEqual(
                10,
                TestRunner.Run(@"
static int Fu() {
    return 10;
}
",
@"
return Fu();
"));
        }

        [TestMethod]
        public void WithArrowExpressionBody()
        {
            Assert.AreEqual(
                10,
                TestRunner.Run(@"
static int Fu() => 10;
", 
@"
return Fu();
"));
        }

        [TestMethod]
        public void Overloading()
        {
            Assert.AreEqual(
                10,
                TestRunner.Run(@"
static int Fu() => 10;
static int Fu(int n) => 15;
",
@"
return Fu();
"));

            Assert.AreEqual(
                15,
                TestRunner.Run(@"
static int Fu() => 10;
static int Fu(int n) => 15;
",
@"
return Fu(1);
"));
        }

        [TestMethod]
        public void DefaultParam()
        {
            Assert.AreEqual(
                99,
                TestRunner.Run(@"
static int Fu(int n = 99) => n;
",
@"
return Fu();
"));

            Assert.AreEqual(
                24,
                TestRunner.Run(@"
static int Fu(int a = 2, int b = 3, int n = 4) => 24;
",
@"
return Fu();
"));
        }
    }
}
