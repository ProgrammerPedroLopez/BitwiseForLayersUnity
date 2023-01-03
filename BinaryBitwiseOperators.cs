using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryBitwiseOperators : MonoBehaviour
{
    uint example;
    uint complement_operator;
    uint left_shift_operator;
    uint right_shift_operator;

    uint variable_a;
    uint variable_b;
    uint logical_and;
    uint logical_or;
    uint logical_xor;

    string result;

    void Start()
    {
        example = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
        result = "Original " + Convert.ToString(example, toBase: 2);
        Debug.Log(result);

        complement_operator = ~example;
        result = "Complement " + Convert.ToString(complement_operator, toBase: 2);
        Debug.Log(result);

        /*
         * The ~ operator produces a bitwise complement of its operand by reversing each bit
         */

        //input
        //0000 1111 0000 1111 0000 1111 0000 1100
        //output
        //1111 0000 1111 0000 1111 0000 1111 0011

        left_shift_operator = example << 4;
        result = "Left shift " + Convert.ToString(left_shift_operator, toBase: 2);
        Debug.Log(result);

        /*
         * The left shift operator moves to the left all the bits and fills withs 0's the right part
         */

        //input
        //0000 1111 0000 1111 0000 1111 0000 1100
        //output
        //1111 0000 1111 0000 1111 0000 1100 0000

        right_shift_operator = example >> 4;
        result = "Right shift " + Convert.ToString(right_shift_operator, toBase: 2);
        Debug.Log(result);

        /*
         * The right shift operator moves to the right all the bits 
         * if the type of the variable is uint or ulong the left empty space is fill withs 0's (logical shift)
         * if the type of the variable is int or long the left empty space is fill with the value of bit sign
         * 0 for positives and 1 for negatives (arithmetic shift)
         */

        //input
        //0000 1111 0000 1111 0000 1111 0000 1100
        //output
        //0000 0000 1111 0000 1111 0000 1111 0000

        //Unsigned right-shift operator >>>
        //performs a logical shift even with signed variables, avaible in C# 11
        //int x = -8;
        //int y = x >>> 2;

        variable_a = 0b_1111_1000;
        variable_b = 0b_1001_1101;

        logical_and = variable_a & variable_b;
        result = "Logical AND " + Convert.ToString(logical_and, toBase: 2);
        Debug.Log(result);
        //Output
        //1001 1000

        /*
         * 1 & 1 = 1
         * 1 & 0 = 0
         * 0 & 1 = 0
         * 0 & 0 = 0
         */

        logical_or = variable_a | variable_b;
        result = "Logical OR " + Convert.ToString(logical_or, toBase: 2);
        Debug.Log(result);
        //Output
        //1111 1101

        /*
         * 1 | 1 = 1
         * 1 | 0 = 1
         * 0 | 1 = 1
         * 0 | 0 = 0
         */

        logical_xor = variable_a ^ variable_b;
        result = "Logical XOR " + Convert.ToString(logical_xor, toBase: 2);
        Debug.Log(result);
        //Output
        //0110 0101

        /*
         * 1 ^ 1 = 0
         * 1 ^ 0 = 1
         * 0 ^ 1 = 1
         * 0 ^ 0 = 0
         */

    }
}
