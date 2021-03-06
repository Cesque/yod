﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using yod;
using yod.Grammar;
using yod.Orthography;
using yod.Phonology;

namespace yodTest
{
    public class Tests
    {
        LanguagePhonology phonology;
        LanguageOrthography orthography;
        LanguageGrammar grammar;
        
        Lexicon lexicon;

        public Tests(bool english)
        {
            //Globals.Seed = 11;

            phonology = english ? LanguagePhonology.FromJSON("./english.json") : LanguagePhonology.Generate();
            orthography = LanguageOrthography.Generate(phonology);
            grammar = LanguageGrammar.Generate();

            lexicon = new Lexicon();
            lexicon.Fill("./dictionary.json", phonology);
        }

        public string TestPhrase()
        {
            
            Phrase phrase = new Phrase(grammar, "./inflectioninput.json");

            phrase.Fill(lexicon);

            var flattened = phrase.Flatten();

            var s = "";
            s += "[not inflected]" + Environment.NewLine;
            flattened.ForEach(x => s += x.ToGlossString() + " ");
            s += Environment.NewLine;
            flattened.ForEach(x => s += orthography.Orthographize(x.Inflected) + " ");
            s += Environment.NewLine;
            s += "/";
            flattened.ForEach(x => s += x.Lemma.ToString() + " ");
            s += "/";

            return s;
        }

        public string TestInflectedPhrase()
        {
            Phrase phrase = new Phrase(grammar, "./inflectioninput.json");
            phrase.Fill(lexicon);

            var subjectSyllable = phonology.GetSyllable();
            var objectSyllable = phonology.GetSyllable();

            List<Inflection> inflections = new List<Inflection>
            {
                new Inflection(phonology, PartOfSpeech.Noun, "GEN"),
                new Inflection(phonology, PartOfSpeech.Noun, "OBJ"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "GEN"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "OBJ"),
            };

            phrase.InflectAll(inflections);
            var flattened = phrase.Flatten();

            var s = "";
            s += "[inflected]" + Environment.NewLine;
            flattened.ForEach(x => s += x.ToGlossString() + " ");
            s += Environment.NewLine;
            flattened.ForEach(x => s += orthography.Orthographize(x.Inflected) + " ");
            s += Environment.NewLine;
            s += "/";
            flattened.ForEach(x => s += x.Inflected.ToString() + " ");
            s += "/";

            return s;
        }

        public string TestQuickBrownFox()
        {
            Phrase phrase = new Phrase(grammar, "./pangram.json");
            phrase.Fill(lexicon);

            List<Inflection> inflections = new List<Inflection>
            {
                new Inflection(phonology, PartOfSpeech.Noun, "GEN"),
                new Inflection(phonology, PartOfSpeech.Noun, "OBJ"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "GEN"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "OBJ"),
            };

            phrase.InflectAll(inflections);
            var flattened = phrase.Flatten();

            var s = "";

            flattened.ForEach(x => s += x.ToGlossString() + " ");
            s += Environment.NewLine;
            flattened.ForEach(x => s += orthography.Orthographize(x.Inflected) + " ");
            s += Environment.NewLine;
            s += "/";
            flattened.ForEach(x => s += x.Inflected.ToString() + " ");
            s += "/";

            return s;
        }

        public string TestLexicon()
        {
            return lexicon.ToString();
        }

        public string TestLexiconOrthographized()
        {
            return lexicon.ToString(orthography);
        }


        public string TestBirthday()
        {
            Phrase birthday1 = new Phrase(grammar, "./birthdayinput1.json");
            Phrase birthday2 = new Phrase(grammar, "./birthdayinput2.json");

            birthday1.Fill(lexicon);
            birthday2.Fill(lexicon);

            List<Inflection> inflections = new List<Inflection>
            {
                new Inflection(phonology, PartOfSpeech.Noun, "OBJ"),
                new Inflection(phonology, PartOfSpeech.Noun, "SBJ"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "SBJ"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "SBJ"),
                new Inflection(phonology, PartOfSpeech.Pronoun, "GEN"),
                new Inflection(phonology, PartOfSpeech.Noun, "GEN"),
            };
            
            birthday1.InflectAll(inflections);
            birthday2.InflectAll(inflections);

            var flattened1 = birthday1.Flatten();
            var flattened2 = birthday2.Flatten();

            var gloss1 = String.Join(" ", flattened1.Select(x => x.ToGlossString()));
            var line1 = "/" + String.Join(" ", flattened1.Select(x => x.Inflected.ToString())) + "/";
            var orth1 = String.Join(" ", flattened1.Select(x => orthography.Orthographize(x.Inflected)));
            var gloss2 = String.Join(" ", flattened2.Select(x => x.ToGlossString()));
            var line2 = "/" + String.Join(" ", flattened2.Select(x => x.Inflected.ToString())) + "/";
            var orth2 = String.Join(" ", flattened2.Select(x => orthography.Orthographize(x.Inflected)));

            var s = "";
            s += orth1 + Environment.NewLine;
            s += line1 + Environment.NewLine;
            s += gloss1 + Environment.NewLine;
            s += orth1 + Environment.NewLine;
            s += line1 + Environment.NewLine;
            s += gloss1 + Environment.NewLine;
            s += orth2 + Environment.NewLine;
            s += line2 + Environment.NewLine;
            s += gloss2 + Environment.NewLine;
            s += orth1 + Environment.NewLine;
            s += line1 + Environment.NewLine;
            s += gloss1 + Environment.NewLine;
            return s;
        }

        public string TestOrthography()
        {
            var s = "";

            foreach (var phoneme in phonology.Phonemes.AllPhonemes)
            {
                var symboldiff = phoneme.Symbol.Length - Globals.StripTies(phoneme.Symbol).Length;
                s += phoneme.Symbol.PadRight(2 + symboldiff) + " -> " + orthography.Orthographize(phoneme) + Environment.NewLine;
            }

            return s;
        }

        public string TestPhonology()
        {
            var s = "Phonemes:" + Environment.NewLine;
            s += "    Consonants: /";
            phonology.Phonemes.Consonants.ForEach(x => s += x.ToString() + " ");
            s += "/" + Environment.NewLine;
            s += "        Vowels: /";
            phonology.Phonemes.Vowels.ForEach(x => s += x.ToString() + " ");
            s += "/" + Environment.NewLine;
            s += "Syllable structure: " + phonology.SyllableStructure.ToString();

            return s;
        }

        public void Run()
        {
            var s = "";

            var tests = new List<Func<string>>
            {
                TestQuickBrownFox,

                TestBirthday,

                TestPhrase,
                TestInflectedPhrase,
                TestPhonology,
                TestLexiconOrthographized,
                TestOrthography
            };

            tests.ForEach(test =>
            {
                s += test();
                s += Environment.NewLine + Environment.NewLine;
            });


            File.WriteAllText("./output.txt", s);
            Process.Start("notepad.exe", "./output.txt");
        }
    }
}