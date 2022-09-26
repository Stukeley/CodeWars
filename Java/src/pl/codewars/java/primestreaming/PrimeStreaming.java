// Unfinished

package pl.codewars.java.primestreaming;

import java.util.stream.IntStream;

public class PrimeStreaming {

    public static IntStream stream() {

        CustomBitSet bitSet = new CustomBitSet();

        return IntStream.generate(bitSet);
    }
}

