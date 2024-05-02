# 9. [Palindrome Number](https://leetcode.com/problems/palindrome-number/) [[solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/1-9/9.cs)] [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/9.cs)]
| Method                             | Param       | Mean       | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------- |------------ |-----------:|----------:|----------:|-------:|----------:|
| IsPalindrome                       | -2147483648 |  0.3274 ns | 0.0094 ns | 0.0083 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | -2147483648 | 46.9902 ns | 0.9513 ns | 1.5362 ns | 0.0214 |     224 B |
| IsPalindrome_CharArray_SingleArray | -2147483648 | 12.6380 ns | 0.2690 ns | 0.2763 ns | 0.0092 |      96 B |
| IsPalindrome                       | -123456     |  0.3155 ns | 0.0011 ns | 0.0009 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | -123456     | 43.7001 ns | 0.4117 ns | 0.3215 ns | 0.0191 |     200 B |
| IsPalindrome_CharArray_SingleArray | -123456     | 10.7317 ns | 0.0737 ns | 0.0690 ns | 0.0076 |      80 B |
| IsPalindrome                       | 0           |  0.3208 ns | 0.0022 ns | 0.0018 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | 0           | 39.9642 ns | 0.4566 ns | 0.3565 ns | 0.0138 |     144 B |
| IsPalindrome_CharArray_SingleArray | 0           |  4.4074 ns | 0.0448 ns | 0.0374 ns | 0.0031 |      32 B |
| IsPalindrome                       | 121         |  1.9648 ns | 0.0203 ns | 0.0190 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | 121         | 41.5092 ns | 0.5922 ns | 0.5249 ns | 0.0138 |     144 B |
| IsPalindrome_CharArray_SingleArray | 121         |  5.6381 ns | 0.1277 ns | 0.1911 ns | 0.0031 |      32 B |
| IsPalindrome                       | 123454321   |  7.9573 ns | 0.0245 ns | 0.0205 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | 123454321   | 56.2287 ns | 0.9274 ns | 0.8675 ns | 0.0206 |     216 B |
| IsPalindrome_CharArray_SingleArray | 123454321   | 12.9704 ns | 0.1271 ns | 0.1062 ns | 0.0084 |      88 B |
| IsPalindrome                       | 1234543210  |  9.2055 ns | 0.0125 ns | 0.0111 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | 1234543210  | 46.3424 ns | 0.9481 ns | 2.2532 ns | 0.0214 |     224 B |
| IsPalindrome_CharArray_SingleArray | 1234543210  | 10.3764 ns | 0.1321 ns | 0.1171 ns | 0.0092 |      96 B |
| IsPalindrome                       | 2147483647  |  9.2152 ns | 0.0305 ns | 0.0271 ns |      - |         - |
| IsPalindrome_CharArray_Linq        | 2147483647  | 44.2088 ns | 0.3267 ns | 0.2896 ns | 0.0214 |     224 B |
| IsPalindrome_CharArray_SingleArray | 2147483647  | 10.2686 ns | 0.0405 ns | 0.0339 ns | 0.0092 |      96 B |

# 57. [Insert Interval](https://leetcode.com/problems/insert-interval/) ([solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/57.cs)) [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/57.cs)]
| Method           | Param                | Mean           | Error         | StdDev        | Gen0    | Gen1    | Gen2    | Allocated |
|----------------- |--------------------- |---------------:|--------------:|--------------:|--------:|--------:|--------:|----------:|
| Insert           | High volume          |   9,034.869 ns |    24.0856 ns |    18.8045 ns |  7.6294 |       - |       - |   80032 B |
| Insert_Popular   | High volume          |  62,416.274 ns |   802.0896 ns |   669.7811 ns | 41.6260 | 41.6260 | 41.6260 |  342503 B |
| Insert_Editorial | High volume          | 125,829.647 ns | 1,734.5407 ns | 1,622.4904 ns | 83.2520 | 83.2520 | 83.2520 |  604973 B |
| Insert           | [[0,0(...)[0,7] [26] |       9.073 ns |     0.0246 ns |     0.0230 ns |  0.0038 |       - |       - |      40 B |
| Insert_Popular   | [[0,0(...)[0,7] [26] |      21.085 ns |     0.1047 ns |     0.0874 ns |  0.0122 |       - |       - |     128 B |
| Insert_Editorial | [[0,0(...)[0,7] [26] |      39.840 ns |     0.6295 ns |     0.5888 ns |  0.0206 |       - |       - |     216 B |
| Insert           | [[0,1(...)1,11] [33] |       9.992 ns |     0.0296 ns |     0.0277 ns |  0.0053 |       - |       - |      56 B |
| Insert_Popular   | [[0,1(...)1,11] [33] |      24.780 ns |     0.0968 ns |     0.0858 ns |  0.0138 |       - |       - |     144 B |
| Insert_Editorial | [[0,1(...)1,11] [33] |      45.681 ns |     0.1240 ns |     0.1036 ns |  0.0222 |       - |       - |     232 B |
| Insert           | [[1,2(...)[4,8] [41] |      12.284 ns |     0.0376 ns |     0.0314 ns |  0.0046 |       - |       - |      48 B |
| Insert_Popular   | [[1,2(...)[4,8] [41] |      24.745 ns |     0.0813 ns |     0.0679 ns |  0.0130 |       - |       - |     136 B |
| Insert_Editorial | [[1,2(...)[4,8] [41] |      62.076 ns |     0.6051 ns |     0.5660 ns |  0.0298 |       - |       - |     312 B |
| Insert           | [[1,2(...)2,10] [21] |       8.118 ns |     0.1528 ns |     0.1354 ns |  0.0031 |       - |       - |      32 B |
| Insert_Popular   | [[1,2(...)2,10] [21] |      18.700 ns |     0.1576 ns |     0.1474 ns |  0.0115 |       - |       - |     120 B |
| Insert_Editorial | [[1,2(...)2,10] [21] |      35.912 ns |     0.5104 ns |     0.4774 ns |  0.0198 |       - |       - |     208 B |
| Insert           | [[1,2],[5,6]], [2,5] |       8.079 ns |     0.1705 ns |     0.1423 ns |  0.0031 |       - |       - |      32 B |
| Insert_Popular   | [[1,2],[5,6]], [2,5] |      18.019 ns |     0.0442 ns |     0.0369 ns |  0.0115 |       - |       - |     120 B |
| Insert_Editorial | [[1,2],[5,6]], [2,5] |      35.797 ns |     0.2310 ns |     0.2047 ns |  0.0198 |       - |       - |     208 B |
| Insert           | [[1,3(...)[3,3] [26] |       9.513 ns |     0.1241 ns |     0.1160 ns |  0.0046 |       - |       - |      48 B |
| Insert_Popular   | [[1,3(...)[3,3] [26] |      22.563 ns |     0.0953 ns |     0.0845 ns |  0.0130 |       - |       - |     136 B |
| Insert_Editorial | [[1,3(...)[3,3] [26] |      42.056 ns |     0.1784 ns |     0.1669 ns |  0.0214 |       - |       - |     224 B |
| Insert           | [[2,4(...)[3,6] [35] |       9.515 ns |     0.0469 ns |     0.0416 ns |  0.0046 |       - |       - |      48 B |
| Insert_Popular   | [[2,4(...)[3,6] [35] |      24.015 ns |     0.0719 ns |     0.0637 ns |  0.0130 |       - |       - |     136 B |
| Insert_Editorial | [[2,4(...)[3,6] [35] |      58.026 ns |     0.1633 ns |     0.1448 ns |  0.0298 |       - |       - |     312 B |
| Insert           | [] [5,7]             |       6.369 ns |     0.0455 ns |     0.0403 ns |  0.0031 |       - |       - |      32 B |
| Insert_Popular   | [] [5,7]             |      15.900 ns |     0.0885 ns |     0.0785 ns |  0.0115 |       - |       - |     120 B |
| Insert_Editorial | [] [5,7]             |       4.131 ns |     0.0154 ns |     0.0144 ns |  0.0031 |       - |       - |      32 B |

# 442. [Find All Duplicates in an Array](https://leetcode.com/problems/find-all-duplicates-in-an-array/) ([solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/442.cs)) [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/442.cs)]
| Method                 | Param             | Mean              | Error           | StdDev            | Gen0      | Gen1      | Gen2     | Allocated |
|----------------------- |------------------ |------------------:|----------------:|------------------:|----------:|----------:|---------:|----------:|
| FindDuplicates_Linq    | Few duplicates    | 23,209,591.518 ns | 461,902.6214 ns |   549,862.2134 ns |  968.7500 |  937.5000 | 343.7500 | 7888463 B |
| FindDuplicates_HashSet | Few duplicates    |  1,508,481.501 ns |  14,756.4314 ns |    13,081.1920 ns |  701.1719 |  671.8750 | 666.0156 | 2852152 B |
| FindDuplicates_Sort    | Few duplicates    |    794,626.993 ns |  15,229.4852 ns |    15,639.5600 ns |  124.0234 |  124.0234 | 124.0234 |  524706 B |
| FindDuplicates_Inverts | Few duplicates    |    521,465.326 ns |   8,235.8897 ns |     7,703.8563 ns |  124.0234 |  124.0234 | 124.0234 |  524706 B |
| FindDuplicates_Linq    | Many duplicates   | 26,241,582.772 ns | 518,827.6842 ns | 1,339,259.9277 ns | 1218.7500 | 1187.5000 | 500.0000 | 9862840 B |
| FindDuplicates_HashSet | Many duplicates   |  2,349,610.124 ns |  46,328.0385 ns |    77,403.7449 ns |  632.8125 |  609.3750 | 601.5625 | 5093013 B |
| FindDuplicates_Sort    | Many duplicates   |    746,346.073 ns |   2,388.1816 ns |     2,117.0608 ns |   41.0156 |   41.0156 |  41.0156 |  262510 B |
| FindDuplicates_Inverts | Many duplicates   |    554,771.221 ns |   3,404.3161 ns |     2,842.7581 ns |  166.0156 |  166.0156 | 166.0156 |  655792 B |
| FindDuplicates_Linq    | [4,3,2,7,8,2,3,1] |        188.344 ns |       1.8678 ns |         1.6558 ns |    0.0987 |         - |        - |    1032 B |
| FindDuplicates_HashSet | [4,3,2,7,8,2,3,1] |         71.003 ns |       0.6614 ns |         0.5523 ns |    0.0390 |         - |        - |     408 B |
| FindDuplicates_Sort    | [4,3,2,7,8,2,3,1] |         21.785 ns |       0.2340 ns |         0.2189 ns |    0.0069 |         - |        - |      72 B |
| FindDuplicates_Inverts | [4,3,2,7,8,2,3,1] |         22.850 ns |       0.4272 ns |         0.3996 ns |    0.0095 |         - |        - |     100 B |
| FindDuplicates_Linq    | []                |         49.553 ns |       0.4696 ns |         0.3921 ns |    0.0352 |         - |        - |     368 B |
| FindDuplicates_HashSet | []                |          5.942 ns |       0.1557 ns |         0.1599 ns |    0.0092 |         - |        - |      96 B |
| FindDuplicates_Sort    | []                |          3.477 ns |       0.1110 ns |         0.2084 ns |    0.0031 |         - |        - |      32 B |
| FindDuplicates_Inverts | []                |          3.191 ns |       0.1003 ns |         0.0938 ns |    0.0031 |         - |        - |      32 B |

# 791. [Custom Sort String](https://leetcode.com/problems/custom-sort-string/) ([solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/791.cs)) [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/791.cs)]
| Method                                   | Param                | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------------------------- |--------------------- |----------:|---------:|---------:|-------:|----------:|
| CustomSortString                         | (akbeyp, epybak)     | 165.82 ns | 1.545 ns | 1.718 ns | 0.0443 |     464 B |
| CustomSortString_BruteSorter             | (akbeyp, epybak)     | 113.11 ns | 2.080 ns | 1.946 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (akbeyp, epybak)     | 149.07 ns | 1.157 ns | 1.026 ns | 0.0443 |     464 B |
| CustomSortString                         | (ejvdt, vtedjq)      | 160.84 ns | 1.805 ns | 1.689 ns | 0.0443 |     464 B |
| CustomSortString_BruteSorter             | (ejvdt, vtedjq)      |  90.58 ns | 0.984 ns | 0.873 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (ejvdt, vtedjq)      | 122.52 ns | 1.079 ns | 1.009 ns | 0.0443 |     464 B |
| CustomSortString                         | (lppv(...)bpps) [33] | 357.54 ns | 2.305 ns | 2.044 ns | 0.0849 |     888 B |
| CustomSortString_BruteSorter             | (lppv(...)bpps) [33] | 573.45 ns | 2.942 ns | 2.608 ns | 0.0105 |     112 B |
| CustomSortString_BruteSorter_MappedOrder | (lppv(...)bpps) [33] |        NA |       NA |       NA |     NA |        NA |
| CustomSortString                         | (qcgl(...)gqlo) [22] | 251.88 ns | 2.484 ns | 2.323 ns | 0.0825 |     864 B |
| CustomSortString_BruteSorter             | (qcgl(...)gqlo) [22] | 226.07 ns | 1.975 ns | 1.751 ns | 0.0083 |      88 B |
| CustomSortString_BruteSorter_MappedOrder | (qcgl(...)gqlo) [22] |        NA |       NA |       NA |     NA |        NA |
| CustomSortString                         | (rngzbwt, zwrngtb)   | 184.20 ns | 1.431 ns | 1.338 ns | 0.0443 |     464 B |
| CustomSortString_BruteSorter             | (rngzbwt, zwrngtb)   | 103.32 ns | 0.710 ns | 0.593 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (rngzbwt, zwrngtb)   | 125.98 ns | 2.372 ns | 2.330 ns | 0.0443 |     464 B |
| CustomSortString                         | (sjvtdzuf, vufjdstz) | 231.80 ns | 2.047 ns | 1.815 ns | 0.0818 |     856 B |
| CustomSortString_BruteSorter             | (sjvtdzuf, vufjdstz) | 172.31 ns | 0.383 ns | 0.359 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (sjvtdzuf, vufjdstz) | 239.32 ns | 1.401 ns | 1.242 ns | 0.0815 |     856 B |
| CustomSortString                         | (smjz(...)vhpm) [26] | 292.40 ns | 1.224 ns | 1.022 ns | 0.0830 |     872 B |
| CustomSortString_BruteSorter             | (smjz(...)vhpm) [26] | 358.92 ns | 0.556 ns | 0.493 ns | 0.0091 |      96 B |
| CustomSortString_BruteSorter_MappedOrder | (smjz(...)vhpm) [26] |        NA |       NA |       NA |     NA |        NA |
| CustomSortString                         | (uohkbpsf, shkfpbuo) | 231.56 ns | 1.208 ns | 0.943 ns | 0.0818 |     856 B |
| CustomSortString_BruteSorter             | (uohkbpsf, shkfpbuo) | 200.07 ns | 0.432 ns | 0.383 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (uohkbpsf, shkfpbuo) | 262.49 ns | 1.319 ns | 1.234 ns | 0.0815 |     856 B |
| CustomSortString                         | (vwlt(...)kext) [24] | 274.53 ns | 1.789 ns | 1.586 ns | 0.0830 |     872 B |
| CustomSortString_BruteSorter             | (vwlt(...)kext) [24] | 255.30 ns | 0.456 ns | 0.404 ns | 0.0091 |      96 B |
| CustomSortString_BruteSorter_MappedOrder | (vwlt(...)kext) [24] | 331.54 ns | 1.231 ns | 1.091 ns | 0.0830 |     872 B |
| CustomSortString                         | (yxiuqmg, muygxiq)   | 182.26 ns | 0.504 ns | 0.447 ns | 0.0443 |     464 B |
| CustomSortString_BruteSorter             | (yxiuqmg, muygxiq)   | 116.54 ns | 0.235 ns | 0.208 ns | 0.0076 |      80 B |
| CustomSortString_BruteSorter_MappedOrder | (yxiuqmg, muygxiq)   | 149.28 ns | 0.980 ns | 0.818 ns | 0.0443 |     464 B |

# 977. [Squares of a Sorted Array](https://leetcode.com/problems/squares-of-a-sorted-array/) ([solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/977.cs)) [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/977.cs)]
| Method             | Param              | Mean         | Error      | StdDev     | Gen0   | Allocated |
|------------------- |------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| SortedSquares      | 1 element          |     3.716 ns |  0.0188 ns |  0.0167 ns | 0.0031 |      32 B |
| SortedSquares_Linq | 1 element          |    24.519 ns |  0.0612 ns |  0.0511 ns | 0.0107 |     112 B |
| SortedSquares      | 2 elements         |     4.649 ns |  0.0467 ns |  0.0437 ns | 0.0031 |      32 B |
| SortedSquares_Linq | 2 elements         |    23.918 ns |  0.0462 ns |  0.0433 ns | 0.0107 |     112 B |
| SortedSquares      | High number        | 1,473.894 ns |  4.7148 ns |  3.9370 ns | 0.7668 |    8024 B |
| SortedSquares_Linq | High number        | 6,935.957 ns | 82.7703 ns | 77.4234 ns | 0.7706 |    8104 B |
| SortedSquares      | Identical elements |    37.322 ns |  0.1084 ns |  0.0905 ns | 0.0214 |     224 B |
| SortedSquares_Linq | Identical elements |   109.808 ns |  0.3945 ns |  0.3080 ns | 0.0290 |     304 B |
| SortedSquares      | Low variance       |    45.430 ns |  0.1797 ns |  0.1681 ns | 0.0214 |     224 B |
| SortedSquares_Linq | Low variance       |   150.069 ns |  0.5738 ns |  0.5087 ns | 0.0288 |     304 B |
| SortedSquares      | Negative elements  |    39.248 ns |  0.1403 ns |  0.1243 ns | 0.0214 |     224 B |
| SortedSquares_Linq | Negative elements  |   161.732 ns |  1.2997 ns |  1.0853 ns | 0.0288 |     304 B |
| SortedSquares      | Positive elements  |    37.645 ns |  0.1670 ns |  0.1304 ns | 0.0214 |     224 B |
| SortedSquares_Linq | Positive elements  |   108.289 ns |  0.8881 ns |  0.7873 ns | 0.0290 |     304 B |
| SortedSquares      | Random elements    |    43.613 ns |  0.0975 ns |  0.0814 ns | 0.0214 |     224 B |
| SortedSquares_Linq | Random elements    |   214.845 ns |  2.4910 ns |  2.2082 ns | 0.0288 |     304 B |

# 2000. [Reverse Prefix of Word](https://leetcode.com/problems/reverse-prefix-of-word/) ([solutions](https://github.com/adwitkow/LeetCode/blob/master/LeetCode/2000.cs)) [[benchmarks](https://github.com/adwitkow/LeetCode/blob/master/LeetCode.Benchmarks/2000.cs)]
| Method               | Param          | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|--------------------- |--------------- |----------:|----------:|----------:|-------:|-------:|----------:|
| ReversePrefix_Array  | Same character |  9.516 ns | 0.0330 ns | 0.0275 ns | 0.0053 |      - |      56 B |
| ReversePrefix_Memory | Same character |  2.919 ns | 0.0240 ns | 0.0225 ns |      - |      - |         - |
| ReversePrefix_Array  | abcdefd:d      | 11.522 ns | 0.0240 ns | 0.0213 ns | 0.0076 |      - |      80 B |
| ReversePrefix_Memory | abcdefd:d      |  2.485 ns | 0.0232 ns | 0.0217 ns |      - |      - |         - |
| ReversePrefix_Array  | long (end)     | 64.764 ns | 0.1704 ns | 0.1511 ns | 0.1010 |      - |    1056 B |
| ReversePrefix_Memory | long (end)     |  2.445 ns | 0.0147 ns | 0.0130 ns |      - |      - |         - |
| ReversePrefix_Array  | long (start)   | 49.605 ns | 0.1050 ns | 0.0982 ns | 0.1010 | 0.0001 |    1056 B |
| ReversePrefix_Memory | long (start)   |  2.798 ns | 0.0105 ns | 0.0093 ns |      - |      - |         - |