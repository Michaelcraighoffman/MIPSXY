using System;

namespace MIPSXY
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Options opt=new Options(ref args);
			if(args.Length<1) {
				Console.WriteLine("Usage is: mipsxy [compile-options] files");
				return;
			}
			Console.Write("Files: ");
			foreach(string s in args) { 
				Console.WriteLine(s+" "); 
				Parser p=new Parser(opt);
				p.Parse(s);
				p.Print();
			}
			
		}
	}
}
