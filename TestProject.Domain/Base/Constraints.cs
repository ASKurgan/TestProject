using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.Base
{
    public readonly struct Constraints
    {
        public const int SHORT_TITLE_LENGTH = 50;
        public const int MEDIUM_TITLE_LENGTH = 150;
        public const int LONG_TITLE_LENGTH = 600;

        public const int MINIMUM_TITLE_LENGTH = 1;
        public const int MINIMUM_SYMBOLS_FOR_PASSWORD = 6;
    }
}
