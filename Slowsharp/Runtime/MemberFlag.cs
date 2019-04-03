﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slowsharp
{
    [Flags]
    public enum MemberFlag
    {
        None = 0,

        Static = 1,
        Member = 2,

        Public = 4, Protected = 8, Private = 16, Internal = 32
    }

    public static class MemberFlagsExt
    {
        public static bool IsMatch(this SSMemberInfo _this, MemberFlag flag)
        {
            if (flag.HasFlag(MemberFlag.Static) &&
                _this.isStatic == false)
                return false;
            if (flag.HasFlag(MemberFlag.Member) &&
                _this.isStatic == true)
                return false;

            if (flag.HasFlag(MemberFlag.Public) &&
                _this.accessModifier.HasFlag(AccessModifier.Public) == false)
                return false;
            if (flag.HasFlag(MemberFlag.Protected) &&
                _this.accessModifier.HasFlag(AccessModifier.Protected) == false)
                return false;
            if (flag.HasFlag(MemberFlag.Private) &&
                _this.accessModifier.HasFlag(AccessModifier.Private) == false)
                return false;
            if (flag.HasFlag(MemberFlag.Internal) &&
                _this.accessModifier.HasFlag(AccessModifier.Internal) == false)
                return false;

            return true;
        }
    }
}
