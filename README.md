# procAudio

```
index...[1 , 12]

f = 2 ^ (index/12f) * 220f
h = 10^(-t) * sin(2 * pi * f * t);
```

```
data[i] = a * h;
```
