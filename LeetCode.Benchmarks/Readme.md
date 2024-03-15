# 9. [Palindrome Number](https://leetcode.com/problems/palindrome-number/)
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

# 791. [Custom Sort String](https://leetcode.com/problems/custom-sort-string/)
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

# 977. [Squares of a Sorted Array](https://leetcode.com/problems/squares-of-a-sorted-array/)
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