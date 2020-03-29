/*
    Homework of Standardization of acceptance tests in 8 semester.
    Copyright (C) 2020  Sidorenko Mikhail Pavlovich (motherlode.muwa@gmail.com)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;

namespace Patterns.Strategy
{
    public static class AdderHead
    {
        public static void AddHead(this ICanHaveHead that)
        {
            switch(that)
            {
                case Human v: v.AddHead(); break;
                case HTML v : v.AddHead(); break;
                case Head v : v.AddHead(); break;
                default: throw new NotImplementedException("Strategy dose not support.");
            }
        }
        
        private static void AddHead(this Human that)
            => that.data += "I have head on my shoulders.\n";

        private static void AddHead(this HTML that)
        {
            if(that.data.Contains("<head>"))
                return;
            string htmlTag = "<html>\n";
            int begin = that.data.IndexOf(htmlTag);
            that.data = that.data.Insert(begin + htmlTag.Length, "\t<head>\n\t</head>\n");
        }

        private static void AddHead(this Head that)
            => that.IsExists = true;
    }
}
