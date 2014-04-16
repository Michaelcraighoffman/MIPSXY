using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MIPSXY
{
	public enum Token
	{
		//Registers
		r_zero=0,
		r_at=1,
		r_v0=2,
		r_v1=3,
		r_a0=4,
		r_a1=5,
		r_a2=6,
		r_a3=7,
		r_a4=8,
		r_a5=9,
		r_a6=10,
		r_a7=11,
		r_t0=8,
		t_t1=9,
		r_t2=10,
		r_t3=11,
		r_t4=12,
		r_t5=13,
		r_t6=14,
		r_t7=15,
		
		//Instructions
		i_add
		
	}
	
	public class Parser
	{
		Options options;
		List<String> parsedLines;
		public Parser(Options o)
		{
			options=o;
		}
		public void Parse(string filename) {
			string[] lines = File.ReadAllLines(filename);
			foreach(string line in lines) {
				string parsedLine=line.Trim();
				if(options.StripComments) { parsedLine=StripComments(parsedLine); }
				parsedLines.Add(parsedLine);
			}
		}
		
		private string StripComments(string line) 
		{
			int CommentPosition=line.IndexOf('#');
			if(CommentPosition!=-1) {
				line=line.Substring(0,CommentPosition);
			}
			return line;
		}
		
	}
}

