﻿namespace Instrucoes
{
  public class Program
  {
    public void InstrucaoUsing(string[] args) {
      using (System.IO.TextWriter writer = System.IO.File.CreateText("teste.txt")) {
        writer.WriteLine("Line 1");
        writer.WriteLine("Line 2");
        writer.WriteLine("Line 3");
      }
    }
  }
}