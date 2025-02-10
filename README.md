# **Roman to Arabic Numeral Converter**

### **Overview**
Develop a module that converts Roman to Arabic numerals using **Test-Driven Development (TDD)**.

### **Roman Numeral Characters**
| Numeral | Value |
|--------|--------|
| I      | 1      |
| V      | 5      |
| X      | 10     |
| L      | 50     |
| C      | 100    |
| D      | 500    |
| M      | 1000   |

### **Conversion Examples**
- **I → 1**  
- **IV → 4**  
- **IX → 9**  
- **XII → 12**  
- **XL → 40**  
- **LXXX → 80**  
- **C → 100**  
- **DCCC → 800**  
- **MCMXCIX → 1999**  
- **MMXXV → 2025**  
- **MMMCMXCIX → 3999**  

### **Roman Numeral Rules**
The conversion between Arabic numerals and Roman numerals follows specific rules:

1. Roman numerals **I, X, C, M** (basic numbers) may be placed directly next to each other a maximum of **three times**.
2. Roman numerals **V, L, D** (intermediate numbers) may only be placed next to each other **once**.
3. The basic numbers **I, X, C** may only be subtracted from one of the next two largest numerals:
   - **Valid examples:** IV = 4, XL = 40, CD = 400
   - **Invalid examples:** IC = 99, VD = 495, XM = 990

### **Development Approach: Test-Driven Development (TDD)**
1. **Write tests first:** Define test cases covering valid and invalid inputs.
2. **Implement functionality:** Develop the conversion logic to pass the tests.
3. **Refactor:** Improve the implementation while ensuring tests continue to pass.
4. **Repeat:** Expand test coverage and refine logic as needed.  

### **Testing Requirements**
**Valid Cases:** Ensure proper conversion of all supported Roman numerals.  
**Invalid Cases:** Detect incorrect repetition, invalid subtractions, and unexpected characters.
