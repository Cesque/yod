﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using yod;
using yod.Phonology;
using yod.Orthography;
using yod.Grammar;

namespace yodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Globals.SeedRandom(3);

            var syllableStructure = new SyllableStructure()
            {
                OnsetStructure = new List<SyllableStructure.SyllableStructureOption>() {
                    new SyllableStructure.SyllableStructureOption(1, 1f),
                },
                NucleusStructure = new List<SyllableStructure.SyllableStructureOption>() {
                    new SyllableStructure.SyllableStructureOption(1, 1f),
                },
                CodaStructure = new List<SyllableStructure.SyllableStructureOption>() {
                    new SyllableStructure.SyllableStructureOption(0, 0.3f),
                    new SyllableStructure.SyllableStructureOption(1, 0.7f),
                }
            };


            var phonology = new LanguagePhonology(syllableStructure);//new Language(syllableStructure);
            var orthography = new LanguageOrthography(LanguageOrthography.DefaultOrthography, phonology);
            phonology.WordLengthMin = 1;
            phonology.WordLengthMax = 4;
            phonology.OnsetConsonants = new List<Consonant>(phonology.Phonemes.Consonants.Where(
                c => true
            ));
            phonology.CodaConsonants = new List<Consonant>(phonology.Phonemes.Consonants.Where(
                c => true
            ));

            var s = "";

            Lexicon lexicon = new Lexicon();
            lexicon.Fill("./input.txt", phonology);

            InputSentence input = new InputSentence();
            input.Subject = new InputWord("i", PartOfSpeech.PRONOUN, "SBJ");
            input.Verb = new InputWord("love", PartOfSpeech.VERB, "PRS");
            input.Object = new InputWord("you", PartOfSpeech.PRONOUN, "OBJ");

            Sentence sentence = new Sentence(input, lexicon, phonology);

            List<string> s1 = new List<string>();
            List<string> s2 = new List<string>();
            foreach (var word in sentence.Words)
            {
                s1.Add(word.Phonemes.ToString());
                s2.Add(word.EnglishLemma.ToString());
            }

            string line1 = "", line2 = "";
            for (var i = 0; i < s1.Count; i++)
            {
                var e = s2[i] + "-" + String.Join("-", sentence.Words[i].GetSmallCapsTags().ToArray());
                var x = s1[i].Count(y => y == '\u0361');
                var length = Math.Max(s1[i].Length - x, e.Length);
                line1 += s1[i].PadRight(length + x) + " ";
                line2 += e.PadRight(length) + " ";
            }

            s += line1 + Environment.NewLine;
            s += line2 + Environment.NewLine;

            File.WriteAllText("./words.txt", s);
            Process.Start("notepad.exe", "./words.txt");


        }
    }
}