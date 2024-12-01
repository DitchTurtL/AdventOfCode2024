﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Jello, Day 1!");
BenchmarkRunner.Run<Runner>();

public class Runner
{
    [Benchmark]
    /// <summary>
    /// Benchmark: Mean = 419.6 us, Error = 1.08 us, StdDev = 1.01 us
    /// </summary>
    public void Day01First()
    {
        string input = """
    88159   51481
    66127   31794
    71500   84893
    59372   58807
    97356   27409
    31813   76811
    58538   17103
    91555   61602
    64368   29057
    93218   29845
    12825   90912
    42007   74860
    86804   22288
    48226   41327
    64901   11672
    23552   90973
    25535   47024
    93958   81020
    22369   12446
    15345   11937
    35777   54941
    56811   12354
    40781   95999
    31307   40172
    91488   82862
    77367   22223
    87964   82070
    74126   93233
    34025   10159
    56705   98596
    95859   86168
    33941   24708
    78232   30124
    26458   71886
    95140   75357
    38239   69088
    28807   41572
    79031   31288
    93268   30124
    45263   38984
    12446   58807
    35553   53820
    48370   97535
    97373   68180
    60564   80931
    37870   50229
    61416   37490
    54388   62859
    41572   95623
    10498   28807
    53226   86218
    87689   16054
    97795   29845
    80217   14003
    61150   41572
    65150   45813
    35662   50581
    21936   28176
    53640   19521
    60440   29845
    10153   73124
    24947   61602
    94719   82862
    56113   35462
    60158   12446
    16511   55130
    43996   68926
    24204   33490
    32322   21742
    29486   81363
    44613   49177
    21869   37110
    22633   60158
    64685   14025
    51857   58940
    65477   51481
    55265   85464
    27449   60615
    57282   90912
    98429   30164
    44599   74746
    55836   41572
    35761   10520
    16770   90768
    88443   47024
    73799   96896
    54283   11223
    36745   37490
    72055   29116
    23208   98166
    76062   68978
    69239   12446
    35416   29845
    58855   28807
    78700   50581
    49820   65493
    74221   46522
    84453   64123
    73522   42813
    53956   36823
    85421   44071
    82349   28807
    36383   90912
    59873   79880
    52931   66755
    51511   41572
    71396   68077
    86214   64123
    89366   37490
    81114   69088
    87716   60615
    48314   82862
    95810   51481
    83319   64039
    33704   44006
    84043   75826
    63438   55130
    22956   20936
    23334   23969
    79068   92145
    19690   60158
    35098   37490
    21016   73557
    39693   12173
    79683   57580
    10884   42795
    84894   92497
    15097   71651
    47644   69088
    27336   30124
    64921   41065
    42698   27274
    11114   85693
    94765   83157
    80308   69088
    46222   34636
    70654   12446
    21252   69088
    31201   60170
    42720   37304
    99750   42777
    26996   29845
    28394   37490
    62128   48607
    90460   90033
    82862   66739
    49218   40284
    15265   18834
    20786   64123
    74074   57157
    66198   60615
    89660   72396
    43653   40822
    81085   31745
    49857   24362
    13425   85693
    26655   12966
    96465   22944
    54546   84491
    84929   47359
    71679   58940
    87771   30084
    96928   47024
    40616   39175
    82726   91399
    43422   21966
    47920   62593
    96065   50581
    56557   35920
    54883   64123
    11419   44113
    92089   96078
    19233   29057
    97536   15362
    43703   93300
    10974   45191
    45383   83413
    70045   47893
    94537   85963
    55877   57815
    80630   50968
    11307   88478
    69350   87753
    32900   58940
    57995   58807
    45541   94944
    31424   90186
    51042   85693
    72314   74743
    76936   35712
    93651   29154
    28102   73346
    22350   36252
    73526   12446
    19991   24425
    29351   51369
    46898   90912
    73110   40189
    80101   77193
    38839   16145
    67376   91399
    11250   47024
    71912   88299
    41511   14749
    94061   64768
    18177   84343
    54020   68080
    34136   58940
    70077   97889
    91399   65493
    86988   56633
    58041   61706
    62066   29845
    69820   67783
    41345   81923
    74352   30263
    10396   96314
    73973   30449
    80283   77731
    78598   50935
    45256   91037
    84757   28807
    59636   26232
    98967   20807
    84663   80838
    44986   12446
    79880   68451
    99523   50581
    58686   63927
    36592   77535
    44131   60615
    81984   35964
    50809   30124
    38038   41392
    77551   28818
    44225   91399
    19856   16346
    81386   30263
    63653   41572
    85880   44359
    83695   40838
    51486   83253
    58871   42663
    67122   40889
    24053   47024
    53285   28807
    96127   26162
    23320   11759
    34681   21742
    27726   32701
    16021   94484
    65391   25875
    15118   21742
    74533   97303
    75277   28807
    84593   93094
    74592   24189
    27084   17154
    64479   52795
    88721   48296
    46709   77926
    38685   86152
    77305   18703
    58118   64123
    95228   21742
    35865   85693
    56841   61602
    27061   11160
    33156   58884
    95075   61602
    62673   62920
    62236   50581
    19545   75640
    32657   51481
    28914   61602
    43029   29333
    99724   69088
    38488   81952
    82519   41572
    73670   15253
    25813   41316
    52085   89329
    58873   94484
    43443   23458
    90391   63012
    21742   46006
    87685   64123
    45047   63653
    63658   77305
    87042   91399
    97610   21389
    62138   29845
    93425   17097
    72887   48441
    28524   56284
    73240   60158
    27736   29845
    85013   32754
    51161   58807
    59013   61602
    77441   60158
    51356   68978
    64926   79276
    14614   61089
    64123   60615
    95766   55863
    19177   57996
    85072   24590
    50207   12446
    29207   63379
    39903   27599
    11221   12456
    68381   82309
    60130   41647
    85523   34848
    98173   66840
    75760   65493
    30335   29845
    49433   30657
    79644   81904
    77896   38729
    71894   14005
    25322   86650
    89785   89651
    33104   87070
    53782   20169
    82382   22858
    38821   61206
    51537   95593
    62183   29845
    78616   68693
    29979   58940
    80974   50647
    85084   60615
    87281   84459
    94553   75854
    75450   37490
    14527   85693
    51616   41572
    46835   52088
    97084   64123
    64764   50276
    57256   37490
    19078   85693
    65241   91405
    38149   58940
    93011   94016
    62890   12446
    21483   21742
    85614   41572
    92234   85693
    74713   30263
    49473   57120
    33659   68978
    38796   74075
    76905   32312
    76648   28807
    16741   33725
    54599   47439
    78356   30263
    86805   20074
    50808   86000
    50391   80866
    88883   65493
    62179   14674
    33353   96172
    81785   87532
    16293   60578
    62340   12544
    54157   73220
    87672   34082
    80352   62489
    76156   82862
    50132   48336
    15103   89651
    56164   51481
    71178   21200
    33097   48247
    58056   58940
    33197   97717
    93106   58807
    83490   56990
    95888   32626
    80441   91399
    80490   77305
    45307   64138
    87163   35282
    19609   92457
    15632   37592
    19571   63653
    43672   91024
    30584   27172
    80118   60112
    35514   66013
    20159   31841
    64490   69374
    26736   86253
    20795   60615
    90740   88354
    91977   29845
    70776   77305
    96040   70863
    77391   12446
    27885   74312
    43539   53870
    37740   50158
    58943   65493
    83210   85693
    81377   93139
    49532   68479
    42816   23988
    71322   71226
    32883   63407
    71221   20406
    62210   55130
    76602   49389
    98153   54312
    67439   53498
    82076   66843
    93499   21742
    64706   52692
    22740   86324
    65169   98212
    71871   58807
    45115   91399
    82873   37490
    33206   29458
    98384   41572
    36085   29057
    81241   11704
    87733   52409
    92538   85380
    43155   87406
    81416   88183
    61679   41717
    78717   91399
    58807   40284
    80998   10270
    69412   83586
    44954   29789
    70765   35112
    53655   68978
    55574   83623
    77261   79880
    85616   28807
    71446   72633
    76456   13356
    78574   28774
    82146   40284
    97870   41572
    85579   37490
    95238   28002
    78545   55130
    91410   60615
    40694   89651
    48255   20946
    33348   93402
    93578   93113
    41035   77220
    12384   60615
    69551   25521
    14889   45701
    88821   14762
    36209   29057
    69726   82862
    24390   58940
    13896   90912
    32471   39529
    10809   61602
    18458   84756
    59760   68731
    30623   64123
    51481   60615
    60615   83337
    76260   89651
    37428   98024
    58479   50581
    29702   51481
    73937   34194
    43765   57420
    92144   37560
    41161   90912
    58835   51481
    27102   12446
    50288   28807
    51204   61602
    32892   60325
    78796   37535
    48103   88625
    63255   37330
    36536   12446
    67969   50581
    89577   16980
    51340   65493
    67495   30124
    29763   49209
    42095   64123
    28992   83460
    58266   89651
    28171   12446
    62901   40002
    21074   31576
    42094   58940
    56348   58807
    22106   94379
    84597   40911
    84863   11817
    41265   30263
    94940   46502
    70259   84999
    27704   79394
    79769   60615
    98226   31180
    18246   28807
    49638   48644
    51318   30249
    17410   29057
    50581   69088
    68352   62040
    61068   12845
    73802   11560
    69088   78556
    11021   29121
    82934   57912
    94484   37048
    38669   44130
    45048   22193
    40598   31455
    68611   41572
    50442   87759
    27021   64123
    13689   58940
    20611   50581
    20756   37729
    81192   53025
    27151   79880
    30316   16292
    92426   47028
    79502   68324
    81129   55130
    49419   54193
    65108   40284
    80078   14766
    63004   84962
    26621   80066
    96890   86315
    83420   39576
    68978   28807
    91535   79135
    22260   67993
    62003   58807
    64231   82862
    11049   84103
    25620   90912
    42551   28283
    37404   42800
    28109   34836
    65182   36478
    41849   60615
    86207   34873
    89745   41190
    47210   64123
    77033   59912
    93743   46675
    54562   61602
    46606   37490
    25591   65624
    21263   72884
    12526   42845
    42338   89651
    66957   42507
    48964   94173
    47921   41572
    74995   37490
    37898   84123
    85693   81027
    97252   94484
    71510   51481
    29057   41572
    57360   30124
    53937   55130
    96328   53134
    99768   43470
    73658   45825
    63944   23238
    97204   82198
    67971   29290
    52693   96297
    51996   75994
    86746   54618
    93693   19228
    96173   96139
    46002   64123
    18153   72197
    47169   22265
    49412   18020
    22919   95524
    89828   47283
    90251   37490
    14783   51692
    21859   35331
    42703   58807
    35131   68765
    90912   81121
    93601   29845
    38731   96444
    11292   41066
    20477   40810
    25767   30124
    62735   20997
    83894   38722
    36112   61602
    32137   18658
    29604   81626
    48810   64504
    56777   90912
    12213   55130
    37252   77574
    60155   83875
    73835   30263
    78092   85693
    73171   99077
    27781   69088
    23586   33465
    65932   58940
    41892   51472
    84171   60615
    59773   41572
    42717   55130
    88033   41572
    33942   52236
    30170   74015
    69779   96941
    34772   69088
    41471   59150
    12602   14594
    51464   41357
    63864   37490
    56803   40758
    78946   29774
    78682   29463
    38404   40907
    93697   62354
    95263   49150
    35971   81529
    40496   43244
    18275   59865
    63488   60615
    47279   92828
    76235   40284
    47024   40284
    48204   57655
    79902   94484
    75899   95207
    52856   30124
    28994   91292
    71721   60800
    18168   92977
    83711   47489
    32006   61602
    92154   58940
    90072   44164
    63381   40012
    43597   37490
    51845   45941
    84240   65493
    29845   75471
    29665   87955
    38183   21742
    31510   12446
    74161   96025
    44839   77305
    75010   70166
    52677   41776
    81038   11871
    15795   81538
    39594   19065
    25796   20619
    26874   64562
    55168   41572
    55185   95308
    98790   94033
    68926   21742
    83458   50000
    37534   74710
    98776   60615
    94489   50636
    10262   51481
    87451   65769
    32873   58807
    17617   69088
    26559   91399
    39737   46082
    21085   37262
    18762   24816
    49950   89651
    66246   33005
    65251   70635
    83333   87445
    36349   86441
    47515   60615
    80598   18073
    77068   94675
    59829   19580
    39528   45761
    50483   75915
    89651   89651
    80854   74471
    35965   69561
    10669   29862
    22619   50283
    81626   65493
    63775   85693
    20340   54509
    40518   30263
    79300   54529
    61602   76356
    43012   90529
    26410   61768
    58487   21742
    29158   51796
    73076   93540
    31717   74487
    68560   33520
    43265   69375
    64920   24114
    37627   43323
    41958   55130
    37490   58456
    48671   60988
    72182   60858
    74060   51260
    51112   93811
    29722   28822
    82027   50581
    79573   99189
    60561   66195
    58802   58807
    40315   48647
    94396   82862
    47412   29261
    19752   25518
    20776   36674
    24416   41089
    17412   53003
    88457   85693
    77431   66884
    37881   98363
    23851   81626
    19649   37490
    21997   46319
    92991   28807
    76508   28807
    55024   98652
    35268   58807
    76772   58698
    98401   89174
    69719   50581
    33867   25013
    55130   25257
    86316   51593
    67472   97797
    13598   71334
    64756   58940
    66192   21075
    86834   50581
    82334   31418
    67170   54080
    84231   85175
    77374   55736
    48383   69997
    97816   35083
    46418   44008
    97432   68978
    20025   29618
    34972   29353
    48710   95722
    30124   91399
    63947   54320
    25216   30263
    46726   95433
    25921   97266
    15920   60615
    96199   21742
    96692   89779
    90194   46309
    92917   99346
    84214   51481
    87917   39494
    98473   29845
    31968   81502
    31595   58940
    55719   90334
    53818   82862
    88460   80373
    66241   85437
    44832   70606
    41180   38325
    48361   78426
    79072   61602
    30967   98006
    76751   64123
    76045   80845
    37103   82116
    15606   36062
    57469   90912
    84158   58807
    90686   58940
    75406   82862
    56855   98351
    92362   46375
    17352   97370
    94670   27780
    30000   37490
    34318   58940
    81549   60192
    60355   58807
    11818   41302
    41503   64123
    45450   81638
    54432   64123
    96755   90912
    59272   82127
    45804   87874
    57824   32206
    13945   65963
    91621   89651
    16200   41572
    15654   81867
    91263   60158
    75440   58807
    37618   58403
    96220   81196
    45607   99616
    48232   70659
    68800   39888
    95389   62350
    72565   61038
    28645   34788
    99370   61602
    74801   11729
    66856   53836
    31999   93270
    19479   30680
    36037   91399
    60422   30124
    15307   71243
    14192   81519
    16843   66313
    73780   66984
    64745   28807
    25844   65228
    52914   12446
    30770   39758
    51346   80335
    33712   40284
    82755   91125
    76698   25380
    37579   63653
    25222   85693
    14062   36163
    18909   92367
    17026   91399
    45348   87244
    12359   63763
    68378   55130
    38479   43114
    62163   37396
    28793   60615
    38243   85693
    23826   36315
    18188   95534
    63539   81681
    23219   39453
    63340   89651
    54052   30124
    93228   73865
    44206   89651
    36133   43720
    41530   37490
    40284   96458
    36346   57131
    30658   90912
    56819   52705
    88997   27309
    33509   84165
    18435   61332
    20226   60615
    40327   40311
    39477   23764
    76470   40284
    86141   75847
    37722   87469
    53557   30936
    16383   92010
    33676   72824
    90392   89651
    27165   90912
    79430   69088
    30520   89556
    46091   32519
    85276   47024
    17485   58940
    52339   40284
    84120   58906
    23386   21925
    48691   11212
    46723   45689
    52862   32602
    42302   51481
    96073   21951
    50688   58807
    78870   61602
    98556   33798
    86753   12446
    60959   45398
    97912   44045
    78962   78785
    52275   88265
    26878   23157
    64365   96781
    99416   30124
    74224   58165
    68066   85281
    65395   64123
    88612   89651
    83360   51481
    44922   60158
    96441   82946
    17712   71313
    66187   21728
    13154   13482
    40880   90912
    44633   60158
    40221   33194
    58940   26653
    44059   89552
    90113   87601
    65493   60615
    95117   58940
    52824   28807
    92260   32814
    91949   57396
    38337   34999
    12052   18581
    65455   76166
    38658   50581
    75169   37490
    99211   65985
    49401   74047
    85347   63826
    15047   14813
    51218   44570
    73700   49613
    64801   16661
    64009   81630
    20001   30124
    84865   85693
    91981   55200
    19331   46485
    77256   51481
    77609   30263
    15665   33198
    75269   28807
    54877   65701
    43011   23690
    83602   31675
    25228   50009
    11436   85693
    83907   75165
    73844   91399
    30916   51076
    11172   12446
    81604   51481
    52336   81312
    74379   97494
    29776   41572
    68162   51481
    72301   20320
    92824   81862
    51228   82862
    37730   29845
    12279   89300
    76474   58807
    91839   16960
    89102   49965
    12556   23352
    97704   20153
    62691   80924
    65407   29057
    30263   40253
    43102   21122
    42086   21742
    68749   41572
    78146   97896
    38711   37490
    90949   42627
    82510   25811
    21910   29845
    38235   16463
    """;
        var pairs = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var pair in pairs)
        {
            var numbers = pair.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            list1.Add(int.Parse(numbers[0]));
            list2.Add(int.Parse(numbers[1]));
        }

        var sortedList1 = list1.OrderBy(x => x).ToList();
        var sortedList2 = list2.OrderBy(x => x).ToList();

        var result = 0;
        for (int i = 0; i < sortedList1.Count; i++)
        {
            result += Math.Abs(sortedList1[i] - sortedList2[i]);
        }
        Console.WriteLine($"First result: {result}");


        var result2 = 0;
        foreach (var i in list1)
        {
            result2 += (i * list2.Count(m => m == i));
        }
        Console.WriteLine($"Second result: {result2}");
    }
}


