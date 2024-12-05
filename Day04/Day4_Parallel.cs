﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

namespace AOC;
public class Day4
{
    static string input = """
    SAXXAXMMSSSSSXMXMAMXSXMAMAMXXXAMXAXXMXMAXSXMMAMXXXMSSSSSMSSSSSSMSSMMXSAMMMMXSAMXSMMMSASASMXMASMMXSSMXSAMXSAMXMMXXXAMAMXMASXSSMSASXMXSMMMMXXM
    MASXMSMAXAAAMMMAMAMSAMSXSAMSMSMMXMSSMMSAAXASAMSAMXAAAMAMXAASAASAAAASMMASMAAAMXSXAMAASXSASXMSXMASAXAAAAASAXAXAXMMSXMASMMMMSAMXAMMXASXXAAMMMSM
    MAMAAAMXMMMMMAMAXASAMXAAMXAXAAXMAMXAAAMMXMAMAXSAAAMMSMAMMMXMMMMMMMMMAAAMMMMSSXXAMMMMXMMAMXAXASMMMSMMMSSMXSMSMSMAAAMAMAAMAMXMMXMASMMMSSMMSAAX
    MXSMMMSASXSSSSXSXXMAXMMSMMSMSMSMMSSSMMXASMSMXMSXSXXMAXAXXMXSXSASMSMSSMSSXSAMMMMSXSXXXAMXMAXSMMAAAAAAXXAMMAXAAAMMMXMAMSMMAMMMSXMAAAAAMAAAMSSS
    SMMMAXSXSAAAXAAXXXSAMXAAAXMXAAAASAMXAXMASAXASXMAXXMMMSXSXMSMASAXAAAXMAAXXMASAAMAXAAAASMSMSMSASXMSMSMMSAMMXXMMMSMXAMMXXXSASAAAAMSSSMSSMMMAAXA
    XAAXXASASMSMMMMMAXASAMXSAMXSMMSXMASMMMMMMXMMAASXMASMXSAAASAMAMMSSMSMMMMSMMXMXXMMMMMMMMAAAXAXMSXAAXAMASMMSMMSAAXXSXXSASAXAMMMMSMMAMAAAMMXMMSM
    SSMXSAMAMXXAMXAMMMAXXXAXXAMXXMMMXSMMMAAAMMSSSMMAMAMSAMMSMSAAXSAAAMXXXMAXAMXSSSMXXXAAXMSMSMMMXSMMMSXMAXAAAMASMSSXMAXMAMMMSMMMXXMMAMMSMMSAAXAX
    XAAMMMMXMAXAMSSSXMSMMMSMMSAMXMAMMXAXMXMXSAAAAASAMXXMXMXAXSXMAMMSSMMASMMXMMAXAASXXMMSMAXXXMXAXXAMXMMMSSMXMMAXMXXAMMMMMMSAMAMSSSXSXSAAAASXSSMS
    MMMMASMSMMSMMSMXMAXAXAMAAMAMXSXSAMMMSMMSMMSSMMXAXSMSMXSMXMAMMXAMXAXMAXAASXMMSMMSAAAAXSXSXAXSMSXMASAMXAAASMSSMMSMASXAAAMASXMAAAASAMMSMMSAMAXS
    MSSSMSAAXAAMMXXXXXSMMSSMMSAMAMAMXMAAAAXXAAAXASXSMSXMAXXXXXAMXMSSSXMASMSMSASAMAASMMXSXMAMAMMXAMXSXMSMMMMMSAAAMAXXAAMMSSMXMAMMSMSMAMMAMXMASMMS
    XAAAAMMMMSSSMMMSMMAMMAXXXXXMAXAMMSMSSSMSMMSMXMAMASXXXMAMMSXMAMXAMMSXMAXASAMASMMSXMXXAMXMAXAXMSMAMXXMAXSMMMMMMSSMSSXXAXXMAMMAMXMMAMXAXXSMMMAX
    MMMMMMAXMAMXMASAXSASMSSXSAMXSSMXAAMAAXMAXMAMSMMMMMASXMXXXAMXASMAMXSASMMMMMMMMAMXMSAMAMSSXSMMMAMXSASASMSAXXXXAXXMAAMAASASXSMXXAMMSSSXSASXMASM
    XAAMMSMSSSXMMXMXMSASAAXMASMXMAAMSMMSSSSSMMMXXAXSAMXMXXAMMASMMMMMMXMAMAMXAMAMSAMMAMXSAMAMASAMSMMAMMSAMASMMMXMXMMSMSMMSAMAAMMSSMSAXAAASMMAAAXA
    MSXSAAAAXAAMSSMMMMMMMMMSMMSAMMMMXAXMAMAAXXMASMMMSMSMXMXSMAMAAXMASAMAMAMSASAMMAMAMXASASMMAMAXAXMXSXMAMXMXAAXMMXAAXAXXAAMMSMAAAAMMSMMMMASMMMAS
    XAAMXMSMMSMMAAAASAMAXMASAASXSXXMSMMMAMSMMAMXXXAMXXAMXMAMMSSSMMSAXMMAXAXXXXMSMAXSXMXMMMXMAMMMASMSMXXSAMXXMSAMSASXSMSSSXMAXMMSXMMAXXXXMAMSAMXX
    MMSMMMAMAAAXSSMMXASMSMAXMMSMMMMMAAAXSXMAXMMAMSSMSSSSSMASXMAXMXMXSAXSSXSAAMXAMMMXASASXSSSMSAXAAXAMAMMAXMASXXXAAXAAAAXAMMMSXMMXAMSSMSMSMMSMMSS
    XAAMXSAMSSMMMMAMSMMXAMXSXAXAAAASXSMXMASMMAXAMAMXXAAAXXMMAMSMSAXMAMAXAMMMMXSASMAXMSASAAXAXSXMMSSSSXXSXMMMAMSMMSMSMMMSMXSAXMAXMMSMAAAXXAAMAMXX
    XSXSAMAMMMAMXAAMAMMSMSXAMMXSMMMSAXMASMMMSMMSMASMMMMMMMMSSMMASAMXMASMAMXAAXMAMMSMAMAMMMMSMSMSMAAMXMXAXXAXASAAXXAMASAXXAMASMMSAXAMMMMXMMMSSMMX
    MMAMXSMSASMSMSMSXSASXMAMXMAXMXMMMMMAMAAXAXAAMAMAMSMSMSMAAXMMMMXAXAXSAMSMSXMXMAXMXMXMASXMAMAAMMSMMAMSMSMSMSASXMAMAMMSMMMAMAXAXSMXSASXSMXMAAXX
    XMAMAAXSASAMAAXXMMMSAXAXAMXSAASAMXMMSSMSXSSXSSMSMAAMAAMSMMXSAASMMSMMXAXMAMSMMMSMMMMMAMMMAMSMSXXXAXAAAAXAAXXXMXMMXSMXMSMMSXMMXXMASXSAXMAMSMMA
    SXSSMSXMAMMMSMSAMXASMMMSMMAMMMSASXSAAAAMXMXAMXXXSMMMSMXAMAMMMMAMXMASMMXMSMMASAMXAAAMASMSMMXMMXMMSMSMSMSMSMSMSAMXMMMMXAAXXAXXSASASXMAMSAMASXM
    SAMXMMMMMMXMXXSXAXMXMAMAAAXMAXSAMAMMSMMMASXXXXXMASXXAMSSXSAXAMMXMXMMAXSMXAXXMASXSSSSMMMMMMSASAXAAMAXAAAXAXMAMMSXSASXSSSMXMAXSAMASMMMMXASASXS
    MXMASAAAAMAMMMMSSXMAXAXSSMSMMMMXMAMXMAXSMSXMXMASAMXSMXAMXMASMSMAXSXSSMSAXSMMSXMMAMAMAAAAAASAAAASASMSMSMMMSMSMAAAMASAXAAAAMMMMMMMMMAAXSMMASAS
    SASXMMSSMMASASAAMAMAMXMAAMAAMAAMSASAMSXSXSASXSAMASMMXMAXXXAAMAMMXSAAAAMAAXAASAMMAMXMSSSMSAMXMXMMAMXAMAXXXMAMMMMSMMMMMSMSXSAXAAMAAMSXXAXMAMMM
    SASXSAMXMSAXAMAXSSMAXSAMXSSSMMXMSASXSMASASAMMMXSSSMSAXMAMMXMSXSMAMMMMXMMMMAMSAMSSXSAMAXAMXMMSMXXMAXXMAXXMXMXXMAXAAAXAXXMXSASXSSSMXAMXSMMASMM
    MAMAMASAMXAXSMSMAAXSXXAXAAXAAXSAMXMMAMXMAMAMASAMXMAMSSMSMAAXSASMAMAXXAXXMASMSAMXAAMAMAMXMAAXMAMSASXSMSSMMAXMXMSSSMSMXSAMAMAXAAMXMSAMAMXSAXAX
    MMMSMAMASMMMXAXMXMMMMSMMASXSMMSMMSMSXMASAMAMSMASXMAMMMAAASXSMAMMMSASMMSXXXXAXAXMMMMMMMSSSMSMMMMSAMAAXAAASXSMAAXAAAMAAXAAAMMMMMMAMSAMXSAXMSSM
    XXAXMXMAMAXMMMMMAMXXAAASAXAAXXXMASXMXSASMSSXMXXMAXMMXMSMXAMXMAMAXAMAXSAMMSMXSMMSMSAAAXAAAMXAMAMSAMXMMSSXMAAXMSSSMMMMMXSSSXSAXAXAXXAMAMMMMAMA
    SMSSMSASMMMXAXAXAMAMSSXMMMSMMMXMASASXMASAAMAMSMXMMXSSMAMMAMSSMSXMAMSXMAMAAMAMXAAXMXSXXMSMMSMSAXSAMXMAXAMMMMMMXAAXXXAMAAAAASMSMSMMSAMXXAAMASX
    AXXAAAMAAAMSMSMSMSMMAMXAAMAAXMXMSSMMXMAMMMSXMAASXSAAASAXSAMXAMXMMXMMASAMSSMXSMMSXSAXAMMMMXAASMMXXMAMXXMAAXASMMXMMSMAASMMMMMXAAAAXMAMSXSXSXSX
    MXMMMMXSSMMAXAMAMAMMMSXSAXSSMMAXAXXXXMMXSAMAMXSAAMMSMMMMSASXXMAMXSASAMAMAAXXXAMAAMAMXMAAXMMXMSAMXSSXSASXSAAAXMMSAXMSMXAASXXSMSSSXXMMMAXMMXSA
    XXMAMXXXMASMMMMASASMXXMASMXAASMSMMSMMMSMMMSMMMMMXMXAXXMAMMMMSMMMASAMMMMMMSMXMMMMSMAMASMSMXXMAMMAXAAASAMAAMSMAMXMAXXXMSMMMMAMXAMMMSMAMAMAMAMM
    MMSAMXXMMMAAASMMSASAMXMAMXXXMMAAXAAAAAAXMAXMAAAXMSXSMMMSSMSAMASMAMSMAASAMAXAAASXMMASXSXAAMXSMSASAMMMMMMXMMMMMXAMAMSXMASAAAAAMAXAAAMXMAMAMASX
    XASMSMSMASMXMXAXMAMAMMSMSASMSMSMMSSMMSMSMAXSMMSMAXMAAAAXXMAXMAMMAMAMSMSASASMSMSASXXMASAMSSMSASMAAXMXAAXAMXXASAMMAMMASAXSSSXSMSSMMSSMSSSMSASX
    MXSAAAASMSMXXMAMSMSSMAAAMAMAAXMAMAXAXMASMMXSAAXAMMMSSMSMMXSAMAXXAXMXMASAMXSAXMXAMXSMMMSMAXAMAMXMAMXSMSXSSMMASAMSXMSAMMXMXMAXAMXMAAAXMAAXMASM
    XMXMMSMSXMAASXMMSMAMMSMSMSMSMMMAMASMMMSMAMAXMMMSAMAAXMXMSAMASASXSSXMSAMXMASAMSMAMAXAMAXMXMSMAMMXMSXMAMXMAXXAMAMXMAAAXMAXAMXMAMAMMMMMMMMMSASA
    XXAMXMMXMMMMXAAAXMAMMXAAAAAAXAMAMXSXXXAMAMMSSMAXAMSSMSAMMASXMAMAXAAXMSSXAAMAAXSXMMSAMSSSSMAMAXXASMAMAMASAMMSSXMAMXXMMSMSSMMMMMSSSXSAAMXXMASM
    MMXSAMXAMXAAXXMMSSSSMMMMSMSMSSXMSMSASXMSXSAAXMASAMXAXSAMSAMXMSMSMMXMAAXAMXSMMMMXAMMXMAXMASMSSSXMXXAMAXXMXMAMMAMXSMXAXXMAMXAAASXAAXSSMMAXMXMX
    AAXSASMMSSMSXSAAAMMAMSSMXXMMAMAAAAXASAXAXMMSMXMAMSSSMSMMMMSAXAAMAXAMMMSXAMXXAAMSSMSAMMSSMMMAAAMSMSSSXXXAXMXXXAMSXAMSASMSSXSMSMMMMMXAMSMSMSAS
    MSXMASXMAAMAASAMMMXAMXAMSMMMASMMMSMAMMMSMMAXMASAMXAAAXXAXMMMMMSMXMXXAXAMXMASXSAAAASAMXMAASMMMMMAAMAXMASMMMMSMMSXASAMAXXMAMXSMMSSSMSMMAAAAMAM
    SMXMAMAMSSMMMMXMASXSSSMMASXMASAMXXAMAXAAXMAMXAMMMMAMMMSSSMMSAMMMSMMSXSMAAMXSAMMMMMMAMMSSMMAMXXSMSMAMSASAAAAAAXAXMXAMMMMMXXMASAAAAASXXMSMMMAM
    AAAMASXMAAAXSAMMXMAXAAMSASXMASAMSMXMXMXSSMSSMXSAAASAXXAAAAASASMAAAXSASASXSMMXMASAMSAMXAAMSAMXXXAXMAXMAXXMMXSSMMMXSAMXAXXXXMMMMMMMMMMAMAXASAS
    MXMSAXAMSSMMXAMXSMSMMMMMXSAMXSXMASAMXSAXAMAAMASMMSXMXMMSMMMSMMMXMMMMAMAMASAMASXSMMMASMSSMSASXMMMMMSSMSMSMSXXMASAMXAMSSSMMSMAAXXXSAMAMSASXSAS
    XMXMMMXMMAMXMXMAXAXASMMMASAMAMASMSXSAMXSXMSSMMSSMXXMAMAAASASAXMASMMMAMAMXMAMASAMXAMSMMAMASAMXAAMAXMAAXMAAMMMMAMMSXMMXXAMXAMMMMXMMAMSAMXMXMMM
    MMAASXSSSMMAASMMMSMAMXAMASAMXSAMXMMMMMXMAXAAAAMAXMASXSASMMASAMMAXAASASASASXMXMMMMSSMASMMMMMMSSMSMSSMMMSMSMAAMXSAMMAXSSMMSMSASMSMSAMXMXMMXSAM
    ASMSMAMAMXMXSXAAAAMAMXXMASAMXMASAMASMXSSSMSSMMSAMSMMMAMXAMMMMMMSMSMSASMSMSXSAMXMAMAXAMXMXASAMXAAAMXXXAAXAMSSSXSAXSAMMAMAAMSASAAAMXMXXXMAAMAS
    MXMAXXMAMMXXXMSMSXSASXSMAMAMAMXXAXSAMXMAAXMAAAMAXAAAMMASMMSAXXXAAMAMXXXMAMMAMSMSMSAMXXAASXSXMASMMSMMMSSXMAXAXMMMMMAXSAMSSMMAMMMMMMSAMXMMXSAM
    MAMAAMSSSMXSXAXMXMMAMAMMSMSMSXMSAMAMSMMMMMSXMMSXSSSMSAMXXASXXXAMXMXMMAMXMSAAXAAAXMAMXMMMSAMMSAMXXAAAXMMMXMMMMXAAAXMMSAMAMASMMMMSSSMAAMSAMXAA
    MAMXSAAAAXASMXMASXSSMAMAXAAAXAAMAMXXMAXASASAMAXAMXMASMXSMMXXMXMXMXXSSMXAXAXASMMMMSAMXMMASAAAMAXMSSSMSAMASXAAAMSXSMSMSAMXSAMXAAAXMASXMASMXSXM
    XAXSMMSSSMAMMMMMMMAXMXXAXMMMMSXSAMSMSSMAMASMMSSSMSMAMXAXAAMSSSMAMXMAXMSSSMAXMXSXMSMSSSMASXMASMMMAAAAXXMASMSMXXMAXAAASXMAMMMSSMSMSMMMMAXAASAS
    MSSXAAMAMMSMSAAAAMMMMSMMXSAXMAXXASXMAXMXMAMXXAAXXXMMSMMSMMSAAXSXMAMAXMAMAXMXMASAMXAAAAMAMAXMAMXMASMMMSMXSXMASASMSSMXMMMMSMMAMAAAXXAXMAXMXMAM
    XXAMMMSAXXAASMSXSMXMAAAAAXMXSMMXXXAXAMMXMASXMMSMSSSMAAAAXXMMSMMMSXSMSMASXXXMMMSXMSMMSMMAMXMMASMMAXXAAXAAMAAMAAAXXASXMSMAAMMAMSMSSSSSSSXMMMSM
    XXAMXAMMSMMXMMXXXMAMXSSMSXSAMASASXXMSMMASASASXXAAAASXMMXMSAMXAAXXXAXXMAMAXMASAMAXXXXAASXSAAXAAXMASXMSSMMSAMAMSMMSAMXMAMMSXMAMXXMAAMMAMASXAAA
    SMMMXMMASXMXAASMMAMSAMXMAAMASAMMAMXXXASASASAMXMMMSMMXASAMSAMSSMMMSMASXSSMAMAMASXMMSSMXMASXSMSMXMASAAAMAAXASXMAMAMXMXSMSXAAMSSMASMMMMASMMMSSM
    XAAXSAMASMMSMMSASAMMASXMMSMXMMMXAMMMSXMASXMAMXAXAXMXSSMAXSAMXXAAAAMMXAMXAAMAMMMMASAMXAMMMMMAAXXMASMMMSMMXMMMXAMSAMXXMXMMSSMAMMAMSXXMAMAXXAXX
    MXMXMAMASAAXAXSXMASXASAMXMMSAMXSAMAAAXSAMXSSMXSMMSMAMMSSMMXXXSSSMXSSMSMASMSSXSASXMASMMXSAAMSMXMMXMXMASMMASAMMXMXXSXMSAXMAMXMAASAMXXMMSMMMMMA
    SSSMSSMMSMMXMMMASXMMMXMXAAMAXSASASMXSXMAXMAXMAMASXMASAAXAMSMMMAXAAXAAXAXMAXMASASASMMMAAMMXMXXASMXMXMASASASAMXMASMSAAMMSMXXAXXMAMAMXXAAMAAXAS
    XAAAAAAAMASXAAXXAMXAAAXSMSAMSMASAMAAXASMSSMMXASXMAXAMMMSXMAAASAMMXMMMMMMMSMMAMAMMMXAXMMSSSSMMMMAASASAMXMASAASMMSAMMMMSAMXSSSSXSXMXSMSXSSSSMA
    MSMMSMMMXAMMSSXMSSSSSMXAXAMXSMAMMMMMXAMXAMAMMXSXSMMMXSAMXSSSMMASXMXASASAAAAXXMXSASMMMSAXMAMXAAMSMMAMMSSMMMXMSAAMXMXSMSASAMMAXXMAMXAAAAMXMAMM
    XMAMXASAMSSMAXASAMXAAXSAMMSAMMSXXSSSSSMMXSAMSMMAAAAXAMAMXXAXASAMAMSASASMSMSXXXMSASASAMMSMMMMMAMAXMMMSAMXAAAXSMMSAMXSASAMXMMSMSSSMAMMMMMASAMX
    MSAMXXMAXXAMASXMASMMMMMAAXMXSAXSMSAMAAAXAMASXAMSMXAMMSAMXMAXXMAXAMMXMAMMMAMMMAAMXMAMSMXAAXAAAXSAMXAMMMSMMMMMXXAXASAMMMXMXMAMMAAAXAXXMASAMXSM
    ASMMSXSXMSMMASASXMXAMXSMMXXAMXSAMMAMSMMMSSMMMSMXXXXMXSASXMASMSSMXSAMMMSXMAMASXXSAMXMXXSSSMMSXMAMXSMMSMAMSSSSSMXSAMASXMMSMMASMMMMMMXMSXXAXXMX
    MXSAXMASAXXMMSAMMMXSXMXAMXMMSSMMMSSMAASAXAAMAMXXXSAMXSXXMASXAAXAXMMMAASAMXSXXAASXMMXMXMAMMMMASAMMASAXXAMAAXSAAAMMMMSAMSAXMAXXXAMASAMXMSMSMSM
    SAMXMSAMSAMXMMXMASMMMMSXMASXSXMXMAMSMSMMSSMSSMMMMMASAMXMXMAAMMMXMAASMMSASAMXMMMMAMAASMMAMAASXMAXSAMMSSSSMMMSMMAXAAMXAXMAMSXSMSXSASASAAAAAAAM
    MMMMXMAMMMAXXSMXSAMXAAMASASMMAASMSXSMAMMAMXAAAAXAMMXAMAMAMSMSMXSMSMSAASAMAMAMAXMASXMMAMXMXMSAMAMMASXMAAXXXMXMMSMSSMSAMXSMMASAAAMXMMMXSMSMMXS
    XAAMXSAMXXSSMAAMMXMMSMSMMMSAMXMXAMAMMMMMAMMSSMMSSSMXSAAXAXAAXAAAMXXSMMXXMAMAXXSSMSASXMMMSMMSXMAMXMAMMMMMMXAAXAAAMAMXAMAMAXAMMMMMASXMMAMXXMAS
    SSXSASAMMAMAAMSASASAXXAAAMSAMXMMXMAMXXSSSMAMAMAAAAMSASMSXSMSMMMSSMASXSSMSSSSSMAAASAMSXAAAAXSXSSSXMAXXXMAXMSMMMSMMAMSXMASAMXXXAAMAMAXMAXAAMAM
    XXAMXSSMSAXAMXXAXAMAMSSSMMMASXMAASXSAAXAXMXMAMMXSAMMAXMAMXAMAXAMAMAMMAAAAAAAAMSMMMMMSMMMSSMMAMMAMMSSXMSSXMASMAMASXMMXMXSMMMXSMSMSXMMSXMSSMSS
    MMXXMXMXSASMMMMSMSMAMXAMXAXAXAMSMSASMXMSMMSMASXXMMAMXMXMASXSAMXSAMASASMMMXMSMMAAMXMXMASAMMAMAMXXAAXXMMAAASASMASMMAAMSAMXAASXMAXXMASASAAMMAMX
    AXAMMXMMMAMXAAAXMASXSXSXSMSMSAMXMMAMXSAXAMAMASMMMMXMASMMAMMMMMMMASASMMAAAAMMMXXSXAAXSAMAXSAMXSXSMSXSAMMMMMAMMMXAXMMMMASMXMXAMAMASMMASMMMMAMS
    SSMMSAMAXMAMXMMMSASXMAXAAAAASXMMMMAMXMASMMXMASMAMAXSAMAMAMMAAAXXXMMXASMMMXSAMXMMXMSMMASMMXASXXAXAAASXSSSSMSMMMSMMMSASMMMXSXMMXSAMXMAMAAMXSSS
    XAAASAMAXXASMMSAMMXAMAMSMMMXMMMAXSXSXSAMXAMMMSMSMSMMASMSMSSSSSSXMASMMMAMXXMAMMSAMMAXSMMMAMSMMMXMXMMMAXAAAAAAAMAMXXMASAAXASAMAXMASMMXSMMSAMAX
    SMMMSXMASMMSAAMXMSSMMAXAMAXAAAXMXMMMMMASAASXASMMXMASAMAMMAMXXXAASMMAXSAMMXSSMXMAMXAXXMMMAMXAMXMMXXMMMMXMMSMSMSASAMMSMMMMASMMXXMXXAMAMMAXXMAM
    MAMMMMMASAASMMMSAXAMMMSSSSSSSMSMSXAXMSMMMSAMXSASASXMASXMMXSXSMSMMASMMMMSXASAXXSSMMSXMASMMXMAMXAAAMASXMMXXXMXXMMMAAXAAAXMAXXAMMMMMSMASAMXSMSM
    MAMAAXMAMMMMAMAMXMXMAXMMAAAAAAAASXMMMAMXXXMAXSAMXMMXMAMXAASXMAAMSASXAXASMMMMAXMAAXAASAMASMSSMSSSMSAMAXMASAMSXMAXXSSMSMXMMSMMSAAAAAMAMMMXSAAS
    XSSSSMSSMSAXAMXSSMSSMSAMMMMSMMMSMAMSSSSSMMXSAMXMXXXMXMSMMXSAMSMMMASMMMMSASAXMSAMXMMMMASAMXAAAAAAAMASMSMMMAXAASAMMMAAAXSMMAAASMSMXXSAAXMAMSMS
    AXAMXAAAASXSMXXMAXAAMSAMXXXXXAXXMXMAAMAAAAAMXSMMMMXSAAXAMXSAMXXXMAMAMAMXAMXSXSASMMXSSXMASMSMMMSMMMAMXAAMSMMSMMASXAMXMSSMSMSMMMXXAAMAMXMMXMSX
    MMAMAXMMMMAAAASMSMSSMSXMXMSSSSXSSSMMSMSMMMXSAMMAMSASMSMSMMSAMMMXMXSXSASMAMAAAMAMAXMAXXSXMMAXAXAAAXAMSSSMAAMXASXMXMASXXMASAMXXSAMSSSMMAXMASXM
    XSXMASMXMMXMMMSAMAMMAMMMMAXAAAASASXMAAXMMMMMMMXAMMASAAMMAMMXSAMMMAMXXAXXAMSMSMASMMMMMXSAXSXSSSSSMMSMMXMMSSMSXMMSMSXMXAMSMAMAXMAXXAAASXMSMSAM
    XASMAMAAMXMSAAMXMAMMXMAAASMMMMMMAMMSMXMXAAAAAMMSXMAMXMSSMMMASASAMASMMSMSXXXAXXAMAAXXXASMMMAMXAMAMXMAMMMAMMXMAXMAMMAMSMMMMMMXMSSMMMMMXAAAMSAM
    SMAMASMMSMASXSMMSXSAMSSSSXMAAMAMAMAXXXXSSXSSXSAXAMXSSMMMAAMMSAMMSASXAXAXSAMXMSMAMMMSMASXAMASMMMMXMSAMAMSXMASMMSMMSAMASAXASMXXAAXAAAXMXSMXSAM
    XXMSASAAXMXMAMAXAAMAXAAMMMMSXSASMXSAMXXMXAMXAMASMMAXMASXXMSAMAMXMASMMMMMMXXAXAMSMSASAMXXXSAMAAAXAXMASMSAASASXASAAMASAMMSXSSSMMSSSSMSAAXMAMXM
    AMXMASMMMSASAMXMXSXMMSXMASAMXSASASMSMSAAMXMMSMMMXMXXSAMSXSMASAMSMMMXAAAAXAMASMSAAMAMSAMXMMXXSSMSMXXAMXMXMMASMXMMMSMMMSMSAMMMAMAMMAMSMMMMASAM
    XXAMXMAAASASASXMXXXMAMASASAMAMXMXMAMMAMMMXSXAAMMMSMMMMAMMSSMMXXAAAMXMSSMSXSASXMMSMMMMMSXMASMMMASMSMXXMXXXMASAMXAAAXAXAAMXMAMAMAMMAMXAXMXASAS
    ASMSMSSMMMASXMAMASAMXMAMASAMMMMMMMMMMAMAXMASXSMAAAAXMMSMAMAMAMXMSMXAMXAMMXMASXXXXAXSAMXAMAMMAXMXAAASXMMMXMAMMMMMMXXASMMMSSSSMSXSSSSSMMSAASAM
    MMAAAMXMXMMMMXAMMXMMMMMMASAMXAAMXMAAMAMXSMXMMAMMXSAMXAAMMSAMASMXMAMSXSAAXXMAMMXMMAMMAXSXMMSMSSXMMMMMAAMMAXASAMASAMSAAXSAAXAAXXAAXMXAAAAMXMMM
    XMSMMMAXMASAXMXMMXSAMXASXMASXSXSASXSSXSAMXAXMASXAMAAMSMSASXSMSAMXAAXASXMSAMAMMXSAMSSSMSXMSAAXMASXMMSSSMSXSASASASAMASMXMMSMSMMMMMMMSSMMAXSAMX
    SAMAMSAMAXSASMSXSAMASMAMXSXMAMASMSAAAASXMSXSMAXMMMSAXAXMASXSMMAASMMMMMMSAXMAMMASASAAXAXAXXMSMSAMAXAMAMAMASXMAMASAMMAXASAXXMXAAAAAXXXSAXMMAMS
    XXSAMXAXSAMXMAAXMAMAAMAMMMMMAMAMXSMMMMMAXAXSMSSMMAMXMASASXMMAXAMXMAXAAXXMXMXSMAMXMMXMXSSMSMXAMXSAMXSAMAMMMASXMXSXMXMMXMASAMXSMSSSSMAAMMXSAMA
    MMMMMSAMMMSAMMMMXAMXXSASAAAMAMXSASMXSASXMMXMAMAXMASMXMAMMAMSSMMXSSSSSSSXXXSASMSMSXSXMXAXAAMMXMMXXMASXSXSASAMASAMXSMXMASXMAMMXAMXAAMSMXAXMMXM
    XXAMXAXXXASXSXMASAXMAXMMXSXMMXXMAXMASMXAAXAMSSMMSXSASMMASXMAMASAMXXAAAMAMXMASAAAMAAAXSAMSMMSXAMASMXMAMASAMASMMASAMMXMASASXMAMSMMMMMAMMSMSMSX
    MSSSMMXMMMSASAMXAMXMAXSSMMXSAASMMMMASMSSMMXSXAXAMXXXMASMMMMXSAMASXMMMMMXSAMAMMMSMXMXMMXMMAASXSMMXMAMMSAMMSXMXSAMXSAXMASAMAMXSMXMASMMSAAAAAAX
    XAAAMXAMXXMXMASMXMXMMSMAAAAMAMMAASMMSAAXAASXXMMMXMMSSMMAXXAMMMSMMMXAAXMASXSSSSXXMAMAMXSMMMMSAXXMASXSAMASXXXAXXSAMXMXMAMMSMMMMMSSMSAMMMSSMSMM
    MMSMMSXSAMSSMMMMSXMASAMXMMSSMXMXMMAMXMASXXSAXMAXAMXMAASMMMMSAXAMAMAXSSMXSAAAAMAMSXMASAMSAAMMXMASASMMMSXMMMMASAASMXSASXSMAAXXAAXAMMMMAMMXXAXA
    AXMAMXMAXSAASXAAMAAXSXXXAXMAMMSXXXAMMSMMXMMXMSSSMSAMMMMXMAASXMMSXXMSMXAXMXMMMMMAAXXXMXSAXMXXASXMMMAMXAAXAAXAXMAXXASASAMMSSMMMSSMMASMSSMASMMS
    MMXXSAMAMMMSMSMSMSSMMAMSAXMAMMAASMMSXAXMMXAAXXMAASMMSAMASXXSMSXMMMXAMXSMSAXAXASMMSAMXMMMASMXXSXXXXXMMSMMSSMMSAMXMXMAMXXAXAXMAAAAMAXAAAXAMMAM
    SAMMSMMASXXXXXMAMAAAMAMAASMMMMMSMAASMMMXAMSSSSMMMMAASXMASMAMXXAAMSMMSAXAXAXSSMSAAMMAMXAXMASMSXMASMSAMXXAXMAMXXMMXSMMMSMMSSMMMSSMSSMSMSMSSXSS
    ASAAMASASXMXXMASMSSMMXSMSMAXMAMAMMMMASMMXXAAAAXXMMMMSXMXSMAMMSMMMXASMXSSXSXXAMXMMSMSMSAXSAAMMAMAAXMASMMSSSSMMAMAAXAXAAAAXAAXAAAXXAAAAMAXSAMX
    MXSSSXMASASXXSAMXAAAAMXXAMAMMMSSXSAXAMAAXSMMMMSMSXAAXAMMSXXSXXMAMXMMAMXXMAMMAMSXMXAAMAAXMMXXMAMXXMMAAXSXAAMMMAMMXSAMSMSMXSMMMSAMXMMMMMSMXMAS
    XMAXMMSXXAXAASMSMSSMMASMSSSMSMAAAMSMSMMSXMASMXSAMXMXSAXAXMSMAMMASAXMMMMMXMSSSMSAAMMMMMSMXXXMXMXSAAMMMSMMMSMAMASAMMXMAAAXMMXXXXXMAXAXAAMASMAS
    SMSMMAMMMSMMMMASAMXMASAMXAXAAMMMSXXXAAXXASMMSAMMMMSAXMASMXXXAAXASXSAMXAMAXXAXASMMSMSAXMAXSMSAAASXMMSMAXAMXXMSAMMXMASMSMAASMSAMXSMSSSMMSAXMAS
    XAMAMSMSAAASXMAMAMSXMMASMAMSMSXAMAMXXMMMMSAAMXSMMXMASMMMAAMMMSMXXAAXSXMSSSMMMXMAXMASXSMXMAASMMMSAMAAMAXMMMAMXXXXAXMMAXXXXAAXASMAXAAAMAMXSMAS
    SXSAMXAMSSSMAMXXMMMAMSAMXMXXXXMASAMSMSAXASMXSAMASASXMMXMSXAXAAXAMSMMMXMAMXAXAXSXMMMMMXMAMMMMAMMMAMSMSSSMSMAMMMMSMXXMASXSAMAMMMXAMSSSMSSMMMAS
    AASXXMMMXXAMXMSMSMSAMMXSASAMXXMAXASAAMAMXMAMMMSAMXXXAXMAMXSMXXSMMAAAAAMAMXMAMMAXSAXAXASAXAXXAMSMSMXAAAAASMSSSMAAMASMMAASAXSXMSSMMAAAXMXMXXAM
    MMMMMXXSMXMMMXAAAAXMXSASXSXXMMMMMMMMSMXXSMSMAAMMSSSMMMSXMAMXSAAASMSMSXSMSSMMXAAMSSSMSXSASXSSSSXAXASMMMMMMAXAAXMMMAXAAMXMXMXAXAAAAMXMMMAMXMAS
    MSAXSAMASAAAXMMSMSMXXMASXMASXSMSAXMAMXXSAMXAMXSAAXXAAAXAMXMAASMMMMXMAXMAAAMSMMMMXAXAAAMAMAAXMAMXMAMAXMAXMMMSMMSSMMSSMSAAAAMSMSXMMSAMASAMAAXA
    SMMXMASAMMSMSAXMAMXXXMXMXMAMAAASMSAMXAXAMASAMAMMSXMMMSXSMAMMMMMMMAAMXMMMMSMXAMXXXAMMMSMSMMMMXMASMXMXSXXMAXAMAMAAAMAMXMMSMSAXXMASASMMMSASXSXA
    SAMASMMMSAMASMMMAMAMSAAMAMASXMMMXXXMMSMSXMXXMXSMMASXMXAMMAMMAXAAXXMXSAASMXMMSMMMXSAXSXAXSXXXSAMXAASAMASMSMAXAMXMMMAMMXMXAMAXMSAMASXSASAMAMAS
    MAMXSXAAMXMAMAASAMAMXASMMSASAAXXXMXSAXAMXMSMSAAAMAMAAXMMSSMSASXXMAAAXXMMMAMXAAAAXXXXXMXMMXMASASXSMSAMXMAXXSSMMSMSSSMSAAMMMAMMMMSAXMAAMXMXXAM
    SSMMMMMMSMMSMMMSMMSMMXMAXMASMMMMAMAMMSMSMSAAMSSMMXSMMMXXAXAMASAASMMMSASXSSSSSSMSSMSMSMAASAMMMMMMAXSMMXMXMMMAAAAAMAAASXSAAMXMXAMMASMSAMXAMMMM
    SAAMMAAMXAAMASAMMAMMMASXMMAXAMXAAMXSXMAAXSMMMXMMMMXMAAXMASMMXMMMMXAASAMXXAAXAMXXAAAAAXSASMSAAASAMXSXSXSXSSSMMSMSXSMMMAXMMSAMXAMMMMMAASXMXSAM
    SXMMSMSSSSMSAMASMASASASMSMMSAMSSMSXXAMMMMXMASAMAAMASMSMAXXXMSMMMSMXMSAMXMMMMMMMMMSMSMXMXMASXSMMMXXMAXAMAMAAXAMMAAXSXMXMXXSASAMSMMSMSASAXXAAS
    SXSXSAAAAXXMASXMMASAMXSAAAXXAMXAMAMMMSAASMSAMAXSASASMAAMMMSAAAXXAAAXSMMSAAXAAAAAXXAAXXXMSXSXMASXSSMSMAMXMSMMASMMMMAMSMMMMXAMMSAXMAXMASXMMSMM
    MAXAMMMMMMASAMMSXAMMMMMAMMMSSXSXMMXAASMMMAMMSXMXASXSMMSASAMSSMMMSSXXMAAXMXMSSSSSXMSMSMMMMMSAMXAXMXAAXAXAXAXXXAXSXMMSAAAMAMSMMSASXSSMAMMAAAAX
    MAMMMMMMAAMMMSASMSMSASMSXXXAXMSAMXMMMMAXMMMASAAMAMAMAAXXMAMXMAMAXAMXMMMSMSMXMMXMMXAXXAAAAXXXMSMSMMMMSMMMSSSSSSXMASXSMXMMXMAAXMAMXMAXAXMMMMSM
    MXSAAAXSSSXSXMASAXAMASAXAMMMXAMAAAAMSSSMSMXASMMMAMAMMMSAMSMAXAMXSASMAAAAAASAMXASAMSSMSSSSSXAMSAAXAAMAMAMAMXAXMASAMXXXSMASXSSMMMMSSMMSMMASMAM
    XAMXXMXMAAMMAMAMMMSMMMMMMMAMSXSAMXSXMAAAAXMXSAAXXSXSXMSMMXASMSSMSAMXSXSMSMMMMSAXSAMAAAAMAXMXAMSMMSXSAMMMMMMAMSAMXSMSMAMASMXAXXAAMAXXAASAXMAM
    MSSMMSMMMMSSMMASXAXXMAXAXSXXAMXXXMXMMMMXMMXMXMMSMAMXAXMMSXAMAXAAXXMAMMAMXXXAAMAMMSSMMMSMXMMSMXMMMMAMAMSAMSSSMXMMAAAAAMMXSXSMMSMSSSMSMMMMSSSM
    XMAMAAAMXAAAASAXMMXSMSXXMSMMASXMSMAAAAMSMMSMXMMAMAMSXMAAMMMMXSMMMMSAMXXSAXMMXSXXAAMAXMXMASAAXMAMAMXMAMMASAAAXMSMSMXMMXXAMMXAAXSAAXAAXASXMAXM
    MSAMSSMMMMSXMMMSASMSAMMXXMASAMMMASXSXXMAAAAAASXXSAXAASMMSXXAAXAAMAMMSXSMMSMMMSXMMSSSMSASXMMMSMXMASMSMSSMMMSMMAAXAXMSSMMMSAMMMMMXMMSMSASAMAMX
    MMXMXAMSSMMXXAXXMSASAMXSSSXMXSASAMXXMMSMSMMMMSAAMXSMAXAXAASMASXMSSMASXXAAXMXAMAMAXAAAXXSMSMMSAXSAMAAMMAMSMAMASXSXSAAAAXSAXXMMXSMMAMXMASXMMSS
    XSASMMMXAASMMMXSAMXMSMXAAMXMSXMMASAXAXSAAAXSAMXMMAMXMXSMSXXAMAMXAXMASMMXMXMMXSAMAMXMXMASAMXAMMMMASMSMSAMXSASXMXAAMMXSMMMASXAMAMAMASXMMMMXAAA
    SXAXASMMMMMAMAAMXMASXSMMSMSXSAXXMMXSXAMMMMAASXMSAMXSXAMXXAASMASAMXMASXAAMAMAMSXMXXXAXMMMSMMMMXXXAMXMASAMXSMSASMMSXSMMMAMAMMMMSSSMAMASMXAMMSS
    MMSMMASXMSSSMMSSXXXAAXXXAAXAMSSXSMAMMSSSSSMMXXAAAXAMMXSAMXXMXXMXMAMAMMSASAMAXSMSXAXSSMSAMXMSSMSMXSAMAMASXSMSAXXAMMMAXXXMAXMAAXAXMXSAMXMSMMAX
    XAXASAMXMXAAASAMMMMMMMMSMSMAMAMAASAXMAAXAAXXMMSMAMASMMMXMMXMXSAMXSMASAXXSXXMMSAMMMMMAAAAMXSAAAAAAXXMMSXAAMAMAMMXSASMMSMSASXMSSSXMAMXMAAAAMAS
    MSSMMSSSSMSMMXAXMAAAMAAXXMAXMAXSASMSMMSMSMMMXAAXXSXSMAMAASMMASASAMMXMXSMMMSMAMXMAXASXMSSMXMMSSMMXSAMASMMSMAMAXMASAMXAAAMAMAAAAMASAXAXXMMXMXS
    MAMXAMMAMAAAXSMMSMSMSMSMXMXXMSAMXXAXXMAMAXAXMSSSXSAMMASMSXAMAMAMASXMSAMAASAMXSASXSAXXXAMXXMXMXXAXSXMAXAXMASMXXSAMAMMSMSMASMMMXSASXMAMSAXSAMX
    SAMMMSMAMSMSAMAAAXAAAAAMMMAMMXXMSMSMXMASXMSAMXAXMMAMSMSXMXSMMXXMAMXAMASXMMMMMSASASMSMMAXMMXAXXMMXMMMMSMXSMMMXMMAXXMAAAXXAAMXMXMASAMAAMAMSAMS
    SASXSMMMXXAXAMMMMXMMMMMSAMSSMAASXAXAXSAMXMAMXMMMAMAMMXMASAXASAMMSSSMSAMAAXXAAMXMAMAAAXMMSASMXSASXSAAMAMXSAAXAMMSMMMSSMMMMSXAMXMASAMSSMSMMAMA
    SXMXAMAMSMMSMMSMSSMMSXMMXXMAMXXXMSMMMMASXSXMSASMSSSMXAXMMMXAMMXMXAAAMMMXMMSMXSMMXMMMMXASMASAASAMASMXXXSAMMMSXSAAAXAAAAXXMAXMSXMAXAMXXAXXXAXA
    SAMMXMAXAAAMAMSAAXMAMAXAMXXAMXSSSMMAASAMXSAASAAAAAAXSSMSASMXSXMMMMMMSMSAMXXAASAMASMAAXMMMAMXMMAMXMSSXSMASMMXAMXSMMMSSXMXMASMAMMXXAMSMXMMSMSM
    SAMSMXSSSMMSSMMMMSMASXMSSSMAMSAXAASXXSMSAMMMMAMMMMMMXMASASAASMMAAXAAAAMMMSXMXMAMASMMSSMAMSSMXSXMASASXASAMAXSMMAXAXMMMMMMXMAXMSAXXAMSXMAMAMAM
    SXMASAMAMXMAMAMAAAXASAAXAXMAMXMSMMMXAXXMMSSMSMXMMMMXXMAMAMMMMASXSSMMSSXMASASMSSMXXAAAAMMMMAMAXMMXMASXMASXXMMXMXSMMSAAAAMMMMMXMAXMSSMAMMSASMX
    XASASXSSMAMASAMMSSSSSMSMAMSSSXMAMAMMSMSXMAMXAAAMSASAMMSMASMXSAMXXAXAAAXMASMMAAMMMSMMSSMMASMMSAMXAMAMAXAMMSAXXXMMMASMSSXSAAASMMSMMXAAXMASASXS
    SXMASXXASXMASMSAAAXAMXAMXMAAMMSAXAXMAAMXMASXSMMXSASAXAXSXXAAASXMSMMMSSXXMXXMMMMAAAAXAAASASAXMASMSSMSSSXAASMMMMXAMXSAMAASMSMSAAMMMSXMMMXSAMMA
    MAMAMXSMMSMMSAMMSSMSSSSSMMMSMASMSMSSMSMAMAMAXAMXMXMMMSMMSMMMMMMAXXXMMMAAXMASASMMSSMMSMMMAXXMXXXXAAAXAXAMXMAAAMMXSAMMMMMMAXXSMMSAAXAMAXAMAMXM
    SAMAAXXXAXXMMMMAXAAAAXMMAAAMMMSAAAMXAMXXXSMMSXMXXXXAAXAASXXAAAXXMMSMAMXMMAAMASAMAMXMXSMMAMSMMMMMSMMMMMSXAXSSXXAXMXXMAXXMMMMXXAMMMSMMAMSSMMSX
    SXSMSMSMSSSMASMMSMMMSXSSSMSSMAMMMSMSMSSSMXAXSASMSMASMSMMSASMSXSMSMAMASMSSSSSMSAMMMMMAASAMXSAAAXXAMAXAAMAXXAAAMSMMMSSMMMAAAASMMSAMXAAXSAAMAMS
    MAXAXAAAAAAMAMAXXAXAAMMAMXAAMXSXXMASAAAAASAMSAMAAAXMAXMAXAMAXASAAAMSASMAAAAAASXMAAAMXMAXSAMXSSMSASMSMMSAMMMMMSXAAAXAAAASMSSXAASAMXMMSMMSMASA
    AMMXMSMMMSMMSSXMSMMMSSMAMMSXMASMSMSMMMSMMMXAMSMSMSXMXMSAMXMXMXMSMSXMASMMMMMMXMASMXSAMXXMSAMXXMMSAMXAMXMASXSSXXXSMSSMMMMXAMXMMMSXMXXMXMSMMXSX
    """;
    static char[] XMAS = ['X', 'M', 'A', 'S'];

    public struct XmasRange
    {
        public Position Start;
        public Position End;

        public XmasRange(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        public override int GetHashCode()
        {
            return (Start.X ^ End.X) << 8 | (Start.Y ^ End.Y);
        }
    }

    public struct Position
    {
        public int X; // I wrote this
        public int Y; // Copilot wrote the rest

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public readonly Position Up => new(X, Y - 1);
        public readonly Position Down => new(X, Y + 1);
        public readonly Position Left => new(X - 1, Y);
        public readonly Position Right => new(X + 1, Y);
        public readonly Position UpLeft => new(X - 1, Y - 1);
        public readonly Position UpRight => new(X + 1, Y - 1);
        public readonly Position DownLeft => new(X - 1, Y + 1);
        public readonly Position DownRight => new(X + 1, Y + 1);

        public override int GetHashCode()
        {
            return (Y << 8) | X; // Except this, I typed "Y <<" and Copilot wrote the rest
        }
    }

    public struct Direction
    {
        public int X; // I wrote this
        public int Y; // Copilot wrote the rest

        public Direction(int x, int y)
        {
            X = x; Y = y;
        }

        public static Direction Up => new(0, -1);
        public static Direction Down => new(0, 1);
        public static Direction Left => new(-1, 0);
        public static Direction Right => new(1, 0);
        public static Direction UpLeft => new(-1, -1);
        public static Direction UpRight => new(1, -1);
        public static Direction DownLeft => new(-1, 1);
        public static Direction DownRight => new(1, 1);

        public static Direction[] AllDirections = new Direction[] { Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight };

        public static Position operator +(Position pos, Direction dir)
        {
            return new Position(pos.X + dir.X, pos.Y + dir.Y);
        }

        public static Position operator -(Position pos, Direction dir)
        {
            return new Position(pos.X - dir.X, pos.Y - dir.Y);
        }

        public static Direction operator -(Direction dir)
        {
            return new Direction(-dir.X, -dir.Y);
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return left.X != right.X || left.Y != right.Y;
        }
    }

    public class SearchTable
    {
        public char[,] Table { get; }
        public int Width => Table.GetLength(0);
        public int Height => Table.GetLength(1);

        public HashSet<XmasRange> FoundRanges = new(4096);

        public SearchTable(char[,] table)
        {
            Table = table;
            Positions = GetPositions();
        }
        public bool InBounds(Position pos)
        {
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;
        }
        public char this[Position pos]
        {
            get => Table[pos.X, pos.Y];
            set => Table[pos.X, pos.Y] = value;
        }

        public Position[] Positions { get; }

        private Position[] GetPositions()
        {
            Position[] positions = new Position[Width * Height];

            int index = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    positions[index++] = new Position(x, y);
                }
            }

            return positions;
        }

        public bool MarkFound(Position start, Position end)
        {
            var range = new XmasRange(start, end);
            if (FoundRanges.Contains(range))
            {
                return false;
            }
            FoundRanges.Add(range);
            return true;
        }
    }

    public static bool CheckX_MAS(SearchTable st, Position pos)
    {
        if (!st.InBounds(pos.UpLeft) ||
            !st.InBounds(pos.DownRight) ||
            !st.InBounds(pos.UpRight) ||
            !st.InBounds(pos.DownLeft))
        {
            return false;
        }

        char upLeft = st[pos.UpLeft];
        char upRight = st[pos.UpRight];
        char downLeft = st[pos.DownLeft];
        char downRight = st[pos.DownRight];

        bool cross1 = (upLeft == 'M' && downRight == 'S') || (upLeft == 'S' && downRight == 'M');
        bool cross2 = (upRight == 'M' && downLeft == 'S') || (upRight == 'S' && downLeft == 'M');

        return cross1 && cross2;
    }

    public static bool CheckXmas(SearchTable st, Position start, Position pos, Direction direction, int depth = 0)
    {
        if (depth == XMAS.Length)
        {
            return true; // st.MarkFound(start, pos);
        }
        if (!st.InBounds(pos))
        {
            return false;
        }
        if (st[pos] != XMAS[depth])
        {
            return false;
        }
        return CheckXmas(st, start, pos + direction, direction, depth + 1);
    }

    static Day4()
    {
        lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

    }

    static string[] lines;
    static SearchTable st;


    [Benchmark]
    public int Part1()
    {
        int count = 0;
        st = new SearchTable(StringArrayToCharArray(lines));

        // Parallel.Foreach with partitioner
        var positions = st.Positions;
        var partitioner = Partitioner.Create(positions, true);

        Parallel.ForEach(partitioner, pos =>
        //foreach (var pos in st.Positions())
        {
            if (st[pos] == 'X')
            {
                for (var i = 0; i < Day4.Direction.AllDirections.Length; i++)
                {
                    if (Day4.CheckXmas(st, pos, pos, Day4.Direction.AllDirections[i]))
                    {
                        Interlocked.Increment(ref count);
                    }
                }
            }
        });

        return count;
    }

    [Benchmark]
    public int Part2()
    {
        int count = 0;
        st = new SearchTable(StringArrayToCharArray(lines));

        var positions = st.Positions;
        foreach (var pos in positions)
        {
            if (st[pos] == 'A')
            {
                if (Day4.CheckX_MAS(st, pos))
                {
                    Interlocked.Increment(ref count);
                }
            }
        }

        return count;
    }

    public static char[,] StringArrayToCharArray(string[] input)
    {
        int width = input[0].Length;
        char[,] arr = new char[input.Length, input[0].Length];
        for (int i = 0; i < input.Length - 1; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                arr[i, j] = input[i][j];
            }
        }
        return arr;
    }
}