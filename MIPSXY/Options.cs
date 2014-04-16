using System;
using System.Collections.Generic;

namespace MIPSXY
{
	public class Options
	{
		private bool stripComments=false;
		public bool StripComments {
			get { return stripComments; }
		}
		public Options(ref string[] args)
		{
			List<string> arguments=new List<string>();
			foreach(string s in args) 
			{
				if(s[0]!='-'){
					arguments.Add(s);
					continue;
				}
				arguments.Remove(s);
				switch(s) {
					case "--help":
						Console.WriteLine("Help:");
						Console.WriteLine("");
						Console.WriteLine("Parser:");
						Console.Write    ("    --strip        ");
						Console.WriteLine("Strip comments from output.");
						Console.Write    ("    --showregister ");
						Console.WriteLine("Displays the contents of x86 registers when they change.");
						Environment.Exit(0);
						break;
					case "--strip":
						stripComments=true;
						break;
					default:
						Console.WriteLine("Unrecognized argument: "+s);
						break;
				}
			}
			args=arguments.ToArray();
		}
	}
}

