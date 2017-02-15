﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace yod.Phonology
{
    public class ConsonantCollection : List<Consonant>
    {
        /*
                |BL   |LD   |D    |AV   |PA   |RF   |AP   |PL   |VE   |UV   |PH   |GL      |LV
                |     |     |     |     |     |     |     |     |     |     |     |        |
        NA      | m   |     |     | n   |     |     |     |     |ɲ    |ŋ    |     |        |
        PL      |pb   |     |     |td   |     |     |     |     |kg   |     |     |ʔ       |
        SAF     |     |     |     |tsdz |tʃdʒ |ʈʂɖʐ |tɕdʑ |     |     |     |     |        |
        NAF     |     |     |tθdð |     |     |     |     |     |     |     |     |        |
        SFR     |     |fv   |θð   |sz   |ʃʒ   |ʂʐ   |ɕʑ   |     |x    |     |     |h       |
        NFR     |     |     |     |     |     |     |     |     |     |     |     |        |
        AP      |     | ʋ   |     | ɹ   |     |     |     |     | j   |     |     |        |ʍw
        TF      |     |     |     |     |     |     |     |     |     |     |     |        |
        TR      | B   |     |     | r   |     |     |     |     |     | R   |     |        |
        LF      |     |     |     |     |     |     |     |     |     |     |     |        |    
        LA      |     |     |     | l   |     |     |     |ʎ    |     |     |     |        |                                                   
        */

        private static readonly List<Consonant> IPAConsonants = new List<Consonant>
        {
            #region consonants
            #region nasals
            new Consonant("m", Consonant.Place.Bilabial, Consonant.Manner.Nasal, Consonant.Phonation.Voiced, 5),
            new Consonant("n", Consonant.Place.Alveolar, Consonant.Manner.Nasal, Consonant.Phonation.Voiced, 5),
            new Consonant("ɲ", Consonant.Place.Palatal, Consonant.Manner.Nasal, Consonant.Phonation.Voiced, 5),
            new Consonant("ŋ", Consonant.Place.Velar, Consonant.Manner.Nasal, Consonant.Phonation.Voiced, 5),
            #endregion
            #region stops
            new Consonant("p", Consonant.Place.Bilabial, Consonant.Manner.Stop, Consonant.Phonation.Unvoiced, 9),
            new Consonant("b", Consonant.Place.Bilabial, Consonant.Manner.Stop, Consonant.Phonation.Voiced, 8),
            new Consonant("t", Consonant.Place.Alveolar, Consonant.Manner.Stop, Consonant.Phonation.Unvoiced, 9),
            new Consonant("d", Consonant.Place.Alveolar, Consonant.Manner.Stop, Consonant.Phonation.Voiced, 8),
            new Consonant("k", Consonant.Place.Velar, Consonant.Manner.Stop, Consonant.Phonation.Unvoiced, 9),
            new Consonant("g", Consonant.Place.Velar, Consonant.Manner.Stop, Consonant.Phonation.Voiced, 8),
            new Consonant("ʔ", Consonant.Place.Glottal, Consonant.Manner.Stop, Consonant.Phonation.Unvoiced, 9),
            #endregion
            #region sibilantaffricates
            new Consonant("t͡s", Consonant.Place.Alveolar, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Unvoiced, 7),
            new Consonant("d͡z", Consonant.Place.Alveolar, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Voiced, 6),
            new Consonant("t͡ʃ", Consonant.Place.Palatoalveolar, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Unvoiced, 7),
            new Consonant("d͡ʒ", Consonant.Place.Palatoalveolar, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Voiced, 6),
            new Consonant("ʈ͡ʂ", Consonant.Place.Retroflex, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Unvoiced, 7),
            new Consonant("ɖ͡ʐ", Consonant.Place.Retroflex, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Voiced, 6),
            new Consonant("t͡ɕ", Consonant.Place.Alveolopalatal, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Unvoiced, 7),
            new Consonant("d͡ʑ", Consonant.Place.Alveolopalatal, Consonant.Manner.Sibilantaffricate, Consonant.Phonation.Voiced, 6),
            
            #endregion
            #region nonsibilantaffricates
            new Consonant("t͡θ", Consonant.Place.Dental, Consonant.Manner.Nonsibilantaffricate, Consonant.Phonation.Unvoiced, 7),
            new Consonant("d͡ð", Consonant.Place.Dental, Consonant.Manner.Nonsibilantaffricate, Consonant.Phonation.Voiced, 6),
            #endregion
            #region sibilantfricatives
            new Consonant("s", Consonant.Place.Alveolar, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("z", Consonant.Place.Alveolar, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Voiced, 6),
            new Consonant("ʃ", Consonant.Place.Palatal, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("ʒ", Consonant.Place.Palatal, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Voiced, 6),
            new Consonant("ʂ", Consonant.Place.Retroflex, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("ʐ", Consonant.Place.Retroflex, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Voiced, 6),
            new Consonant("ɕ", Consonant.Place.Alveolopalatal, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("ʑ", Consonant.Place.Alveolopalatal, Consonant.Manner.Sibilantfricative, Consonant.Phonation.Voiced, 6),         
            #endregion
            #region nonsibilantfricatives
            new Consonant("f", Consonant.Place.Labiodental, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("v", Consonant.Place.Labiodental, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Voiced, 6),
            new Consonant("θ", Consonant.Place.Dental, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("ð", Consonant.Place.Dental, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Voiced, 6),
            new Consonant("x", Consonant.Place.Velar, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Unvoiced, 7),
            new Consonant("h", Consonant.Place.Glottal, Consonant.Manner.Nonsibilantfricative, Consonant.Phonation.Unvoiced, 7),
            #endregion
            #region approximants
            new Consonant("ʋ", Consonant.Place.Labiodental, Consonant.Manner.Approximant, Consonant.Phonation.Voiced, 6),
            new Consonant("ɹ", Consonant.Place.Alveolar, Consonant.Manner.Approximant, Consonant.Phonation.Voiced, 3),
            new Consonant("j", Consonant.Place.Palatal, Consonant.Manner.Approximant, Consonant.Phonation.Voiced, 2),
            new Consonant("ʍ", Consonant.Place.Labializedvelar, Consonant.Manner.Approximant, Consonant.Phonation.Unvoiced, 2),
            new Consonant("w", Consonant.Place.Labializedvelar, Consonant.Manner.Approximant, Consonant.Phonation.Voiced, 2),
            #endregion
            #region flap or tap
            #endregion
            #region trills
            new Consonant("B", Consonant.Place.Bilabial, Consonant.Manner.Trill, Consonant.Phonation.Voiced, 3),
            new Consonant("r", Consonant.Place.Alveolar, Consonant.Manner.Trill, Consonant.Phonation.Voiced, 3),
            new Consonant("R", Consonant.Place.Uvular, Consonant.Manner.Trill, Consonant.Phonation.Voiced, 3),
            #endregion
            #region lateral affricate
            #endregion
            #region lateral fricative
            #endregion

            #region lateral approximants
            new Consonant("l", Consonant.Place.Alveolar, Consonant.Manner.Lateralapproximant, Consonant.Phonation.Voiced, 4),
            new Consonant("ʎ", Consonant.Place.Palatal, Consonant.Manner.Lateralapproximant, Consonant.Phonation.Voiced, 4),
            #endregion
            #region lateral flap
            #endregion
            #endregion
        };

        public static ConsonantCollection AllConsonants => new ConsonantCollection();

        public static ConsonantCollection DefaultConsonants
        {
            get
            {
                var c = new ConsonantCollection(new List<Predicate<Consonant>>
                {
                    consonant => (consonant.PlaceOfArticulation != Consonant.Place.Dental)
                    && (consonant.PlaceOfArticulation != Consonant.Place.Retroflex)
                    && (consonant.PlaceOfArticulation != Consonant.Place.Alveolopalatal)
                    && (consonant.MannerOfArticulation != Consonant.Manner.Trill)
                    && (consonant.Symbol != "ʔ")
                    && (consonant.Symbol != "ʋ")
                });
                return c;
            }
        }

        public ConsonantCollection() : base(IPAConsonants)
        {
        }

        public ConsonantCollection(List<Predicate<Consonant>> add)
        {
            add.ForEach(pred =>
            {
                AddRange(IPAConsonants.Where(c => pred(c)));
            });
        }

        public Consonant GetRandom()
        {
            return this[Globals.Random.Next(Count)];
        }

        public Consonant GetRandomInSonorityRange(int sonorityMin, int sonorityMax)
        {
            var sublist = this.Where(x => x.Sonority <= sonorityMax && x.Sonority >= sonorityMin);
            return sublist.ElementAt(Globals.Random.Next(sublist.Count()));
        }
    }
}
