using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MIPSXY
{
	public enum Token
	{
		instruction,
		register,
		immediate,
		offset,
		label,
		section,
		comment
	}
	
	public class Parser
	{
		Options options;
		List< KeyValuePair<Token,string> > Tokens=new List<KeyValuePair<Token, string>>();
		public Parser(Options o)
		{
			options=o;
		}
		public void Parse(string filename) {
			string[] lines = File.ReadAllLines(filename);
			foreach(string line in lines) {
				string parsedLine=line.Trim();
				if(string.IsNullOrEmpty(parsedLine)) continue;
				Tokenize(parsedLine);
			}
			
		}
		
		public void Print() 
		{
			foreach(var token in Tokens) 
			{
				System.Console.WriteLine(token.Key+" : "+token.Value+"  ");
			}
		}
		private void Tokenize(string line) 
		{
			int CommentPosition=line.IndexOf('#');
			if(CommentPosition!=-1) {
				var newToken=new KeyValuePair<Token,string>(Token.comment, line.Substring(CommentPosition, (line.Length-CommentPosition)));
				Tokens.Add(newToken);
				line=line.Substring(0,CommentPosition);
			}
			string[] possibleTokens=line.Split(' ', ',');
			foreach(string s in possibleTokens) {
				string token=s.Trim();
				if(string.IsNullOrEmpty(token)) continue;
				if(token.Contains("(")) 
				{
					var newToken=new KeyValuePair<Token,string>(Token.offset, token);
					Tokens.Add(newToken);
				}
				if(token[0]=='$') {
					var newToken=new KeyValuePair<Token,string>(Token.register, token);
					Tokens.Add(newToken);
				}
				else if(token[0]=='.')
				{
					var newToken=new KeyValuePair<Token,string>(Token.section, token);
					Tokens.Add(newToken);
				}
				else if(token[token.Length-1]==':')
				{
					var newToken=new KeyValuePair<Token,string>(Token.label, token);
					Tokens.Add(newToken);
				}
				else if(char.IsNumber(token[0])) 
				{
					var newToken=new KeyValuePair<Token,string>(Token.immediate, token);
					Tokens.Add(newToken);
				}
				
				else 
				{
					var newToken=new KeyValuePair<Token,string>(Token.instruction, token);
					Tokens.Add(newToken);
				}
			}
		}
		
		
	}
}

