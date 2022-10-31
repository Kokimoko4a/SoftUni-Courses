﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand,int cores,double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public double Frequency { get; set; }
        public int Cores { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"{Brand} CPU:{Environment.NewLine}"+
           $"Cores: {Cores}{Environment.NewLine}"+
           $"Frequency: {Frequency:f1} GHz";

        }
    }
}
