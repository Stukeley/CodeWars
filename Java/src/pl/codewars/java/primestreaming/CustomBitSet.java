// Unfinished

package pl.codewars.java.primestreaming;

import java.util.BitSet;
import java.util.function.IntSupplier;

class CustomBitSet implements IntSupplier {

    static final int limit = 982_451_654;
    static final int limitSqrt = (int)Math.sqrt(limit);

    static BitSet primes = new BitSet(limit);

    static int index = 2;

    CustomBitSet() {
        primes.set(2, limit, true);
    }

    @Override
    public int getAsInt() {
        // Get to the first prime number.
        while (!primes.get(index)) {
            index++;
        }

        // If we're below sqrt(limit), mark all multiples as non-prime.
        if (index < limitSqrt) {
            for (int j = index * index; j < limit && j > 0; j += index) {
                primes.clear(j);
            }
        }

        return index++;
    }
}