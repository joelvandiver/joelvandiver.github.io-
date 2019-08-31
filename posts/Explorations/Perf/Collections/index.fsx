(**
# PERF Experiments for F# Collection Types
*)

open System

// Define the expected power operator:
let (^) x n = pown x n
let max = Math.Pow(10., 6.)

(**
*Output:*
```console
val ( ^ ) : x:int -> n:int -> int
val max : float = 1000000.0
```
*)


(**
## Initialize a Sequence
*)
#time
let aSeq    = { (-1.*max) .. max }
#time
(**
*Output:*
```console
--> Timing now on

Real: 00:00:00.000, CPU: 00:00:00.000, GC gen0: 0, gen1: 0, gen2: 0
val aSeq : seq<float>


--> Timing now off
```
*)


(**
## Map to a List
*)
#time
let aList   = aSeq |> List.ofSeq
#time
(**
*Output:*
```console
--> Timing now on

Real: 00:00:00.291, CPU: 00:00:00.312, GC gen0: 11, gen1: 6, gen2: 1
val aList : float list =
  [-1000000.0; -999999.0; -999998.0; -999997.0; -999996.0; -999995.0;
   -999994.0; -999993.0; -999992.0; -999991.0; -999990.0; -999989.0; -999988.0;
   -999987.0; -999986.0; -999985.0; -999984.0; -999983.0; -999982.0; -999981.0;
   -999980.0; -999979.0; -999978.0; -999977.0; -999976.0; -999975.0; -999974.0;
   -999973.0; -999972.0; -999971.0; -999970.0; -999969.0; -999968.0; -999967.0;
   -999966.0; -999965.0; -999964.0; -999963.0; -999962.0; -999961.0; -999960.0;
   -999959.0; -999958.0; -999957.0; -999956.0; -999955.0; -999954.0; -999953.0;
   -999952.0; -999951.0; -999950.0; -999949.0; -999948.0; -999947.0; -999946.0;
   -999945.0; -999944.0; -999943.0; -999942.0; -999941.0; -999940.0; -999939.0;
   -999938.0; -999937.0; -999936.0; -999935.0; -999934.0; -999933.0; -999932.0;
   -999931.0; -999930.0; -999929.0; -999928.0; -999927.0; -999926.0; -999925.0;
   -999924.0; -999923.0; -999922.0; -999921.0; -999920.0; -999919.0; -999918.0;
   -999917.0; -999916.0; -999915.0; -999914.0; -999913.0; -999912.0; -999911.0;
   -999910.0; -999909.0; -999908.0; -999907.0; -999906.0; -999905.0; -999904.0;
   -999903.0; -999902.0; -999901.0; ...]


--> Timing now off
```
*)


(**
## Map to a Set
*)
#time
let aSet    = aSeq |> Set.ofSeq
#time
(**
*Output:*
```console
--> Timing now on

Real: 00:00:03.272, CPU: 00:00:03.281, GC gen0: 1028, gen1: 27, gen2: 1
val aSet : Set<float> =
  set
    [-1000000.0; -999999.0; -999998.0; -999997.0; -999996.0; -999995.0;
     -999994.0; -999993.0; -999992.0; ...]


--> Timing now off
```
*)


(**
## Map to a Array
*)
#time
let aArray  = aSeq |> Array.ofSeq
#time
(**
*Output:*
```console
--> Timing now on

Real: 00:00:00.101, CPU: 00:00:00.109, GC gen0: 0, gen1: 0, gen2: 0
val aArray : float [] =
  [|-1000000.0; -999999.0; -999998.0; -999997.0; -999996.0; -999995.0;
    -999994.0; -999993.0; -999992.0; -999991.0; -999990.0; -999989.0;
    -999988.0; -999987.0; -999986.0; -999985.0; -999984.0; -999983.0;
    -999982.0; -999981.0; -999980.0; -999979.0; -999978.0; -999977.0;
    -999976.0; -999975.0; -999974.0; -999973.0; -999972.0; -999971.0;
    -999970.0; -999969.0; -999968.0; -999967.0; -999966.0; -999965.0;
    -999964.0; -999963.0; -999962.0; -999961.0; -999960.0; -999959.0;
    -999958.0; -999957.0; -999956.0; -999955.0; -999954.0; -999953.0;
    -999952.0; -999951.0; -999950.0; -999949.0; -999948.0; -999947.0;
    -999946.0; -999945.0; -999944.0; -999943.0; -999942.0; -999941.0;
    -999940.0; -999939.0; -999938.0; -999937.0; -999936.0; -999935.0;
    -999934.0; -999933.0; -999932.0; -999931.0; -999930.0; -999929.0;
    -999928.0; -999927.0; -999926.0; -999925.0; -999924.0; -999923.0;
    -999922.0; -999921.0; -999920.0; -999919.0; -999918.0; -999917.0;
    -999916.0; -999915.0; -999914.0; -999913.0; -999912.0; -999911.0;
    -999910.0; -999909.0; -999908.0; -999907.0; -999906.0; -999905.0;
    -999904.0; -999903.0; -999902.0; -999901.0; ...|]


--> Timing now off
```
*)

(**

## Summary

|   | Type  | Metrics                                                                 |
| - | ----- | ----------------------------------------------------------------------- |
| 1 | Seq   | Real: 00:00:00.000, CPU: 00:00:00.000, GC gen0: 0, gen1: 0, gen2: 0     |
| 2 | List  | Real: 00:00:00.291, CPU: 00:00:00.312, GC gen0: 11, gen1: 6, gen2: 1    |
| 3 | Set   | Real: 00:00:03.272, CPU: 00:00:03.281, GC gen0: 1028, gen1: 27, gen2: 1 |
| 4 | Array | Real: 00:00:00.101, CPU: 00:00:00.109, GC gen0: 0, gen1: 0, gen2: 0     |

*)