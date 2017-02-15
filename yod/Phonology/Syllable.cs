﻿using System.Collections.Generic;
using System.Linq;

namespace yod.Phonology
{
    public class Syllable
    {
        LanguagePhonology language;
        SyllableStructure structure;
        public List<Phoneme> Phonemes;

        public Syllable(Syllable syllable)
        {
            language = syllable.language;
            structure = syllable.structure;
            Phonemes = new List<Phoneme>();
            syllable.Phonemes.ForEach(x =>
            {
                Phonemes.Add(x.Type == Phoneme.PhonemeType.Consonant
                    ? new Consonant((Consonant) x)
                    : (Phoneme)new Vowel((Vowel) x));
            });
        }
        
        public Syllable(LanguagePhonology l)
        {
            language = l;
            structure = l.SyllableStructure;
            Generate();
        }

        public void Generate()
        {
            Phonemes = new List<Phoneme>();

            //onset
            var length = structure.GetOnsetLength();
            var onset = GetOnset(length);
            Phonemes.AddRange(onset);

            //nucleus
            length = structure.GetNucleusLength();
            for (var i = 0; i < length; i++)
            {
                var v = language.Phonemes.Vowels.GetRandom();
                if (Phonemes.Count > 0) while (Phonemes.Last() == v) v = language.Phonemes.Vowels.GetRandom();
                Phonemes.Add(v);
            }

            //coda
            length = structure.GetCodaLength();
            var coda = GetCoda(length);
            Phonemes.AddRange(coda);
        }

        public override string ToString()
        {
            var s = "";
            Phonemes.ForEach(x => s += x.ToString());
            return s;
        }

        public List<Phoneme> GetOnset(int length)
        {
            var list = new List<Phoneme>();

            var minSonority = 2 + (length - 1);
            var maxSonority = 9;

            for (var i = 0; i < length; i++)
            {
                var cons = language.Phonemes.Consonants.GetRandomInSonorityRange(minSonority, maxSonority);
                minSonority--;
                maxSonority = cons.Sonority - 1;
                list.Add(cons);
            }

            return list;
        }

        public List<Phoneme> GetCoda(int length)
        {
            var list = new List<Phoneme>();

            var minSonority = 2;
            var maxSonority = 9 - (length - 1);

            for (var i = 0; i < length; i++)
            {
                var cons = language.Phonemes.Consonants.GetRandomInSonorityRange(minSonority, maxSonority);
                maxSonority++;
                minSonority = cons.Sonority + 1;
                list.Add(cons);
            }

            return list;
        }
    }
}
