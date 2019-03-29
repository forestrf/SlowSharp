﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Slowsharp
{
    public class SSMethodInfo : SSMemberInfo
    {
        public Invokable target;
        public BaseMethodDeclarationSyntax declaration;

        internal JumpDestination[] jumps;

        internal SSMethodInfo(Runner runner, BaseMethodDeclarationSyntax declaration)
        {
            target = new Invokable(this, runner, declaration);
        }
        internal SSMethodInfo(MethodInfo methodInfo)
        {
            target = new Invokable(this, methodInfo);
        }
    }
}
