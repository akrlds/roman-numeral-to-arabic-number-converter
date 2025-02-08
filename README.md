# Roman Numeral to Arabic Number Converter

### Overview
Develop a module that converts incoming Roman numerals to Arabic numbers using **Test-Driven Development (TDD)**.

## **Conversion Table**

| Roman Number | Arabic Number |
|--------------|--------------|
| I            | 1            |
| II           | 2            |
| III          | 3            |
| IV           | 4            |
| V            | 5            |
| VI           | 6            |
| VII          | 7            |
| VIII         | 8            |
| IX           | 9            |
| X            | 10           |
| XI           | 11           |
| XII          | 12           |
| XIII         | 13           |
| XIV          | 14           |
| XV           | 15           |
| XVI          | 16           |
| XVII         | 17           |
| XVIII        | 18           |
| XIX          | 19           |
| XX           | 20           |
| XXX          | 30           |
| XL           | 40           |
| L            | 50           |
| LX           | 60           |
| LXX          | 70           |
| LXXX         | 80           |
| XC           | 90           |
| C            | 100          |
| CC           | 200          |
| CCC          | 300          |
| CD           | 400          |
| D            | 500          |
| DC           | 600          |
| DCC          | 700          |
| DCCC         | 800          |
| CM           | 900          |
| M            | 1000         |
| MM           | 2000         |
| MMXXV        | 2025         |
| MMM          | 3000         |
| MMMCMXCIX    | 3999         |

## **Roman Numeral Rules**
The conversion between Arabic numerals and Roman numerals follows specific rules:

1. Roman numerals **I, X, C, M** (basic numbers) may be placed directly next to each other a maximum of **three times**.
2. Roman numerals **V, L, D** (intermediate numbers) may only be placed next to each other **once**.
3. The basic numbers **I, X, C** may only be subtracted from one of the next two largest numerals:
   - **Valid examples:** IV = 4, XL = 40, CD = 400
   - **Invalid examples:** IC = 99, VD = 495, XM = 990

## **Development Approach: Test-Driven Development (TDD)**
1. **Write tests first:** Define test cases covering valid and invalid inputs.
2. **Implement functionality:** Develop the conversion logic to pass the tests.
3. **Refactor:** Improve the implementation while ensuring tests continue to pass.
4. **Repeat:** Continue refining based on additional edge cases.

## **Testing Requirements**
- **Valid Cases:**
  - Ensure conversion from Roman numerals to Arabic numbers is correct.
  - Test valid Roman numeral inputs from the table above.
- **Invalid Cases:**
  - Handle incorrect repetition of characters.
  - Detect invalid subtraction patterns.
  - Ensure unexpected characters return errors.
