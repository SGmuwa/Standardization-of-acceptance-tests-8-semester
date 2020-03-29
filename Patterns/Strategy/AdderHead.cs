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

namespace Patterns.Strategy
{
    public static class AdderHead
    {
        public static string AddHumanHead(string human)
            => human + "I have head on my shoulders.\n";

        public static string AddHTMLHead(string html)
        {
            if (html == null)
                html = "";
            if (html.Contains("<head>"))
                return html;
            string htmlTag = "<html>\n";
            int begin = html.IndexOf(htmlTag);
            if (begin < 0)
                begin = html.Length - htmlTag.Length;
            return html.Insert(begin + htmlTag.Length, "\t<head>\n\t</head>\n");
        }

        public static string AddHeadHead(string head = null)
            => "I am head and I exists.";
    }
}
