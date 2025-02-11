# **Roman to Arabic Numeral Converter**

## **Project Overview**
The **Roman to Arabic Numeral Converter** is a C# module designed to convert Roman numerals into Arabic numerals while ensuring correctness and validity. The project follows the **Test-Driven Development (TDD)** approach, ensuring that all functionality is backed by robust unit tests.

This module is structured to handle both valid and invalid Roman numerals, enforcing numeral composition rules and providing meaningful error messages when incorrect inputs are encountered.

---

## **Implementation Details**

### **Numeral Mapping**
The Roman numeral system follows a set of predefined characters:

| Roman | Arabic  |
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
The conversion logic adheres to the following principles:
1. **Repetition Limits:**
   - Roman numerals **I, X, C, M** can appear consecutively up to **three times**.
   - Roman numerals **V, L, D** can appear only **once consecutively**.
2. **Subtraction Rules:**
   - A smaller numeral can only subtract from one of the next two larger numerals.
   - **Valid subtractions:** IV (4), XL (40), CD (400).
   - **Invalid subtractions:** IC (99), VD (495), XM (990).

---

## **Code Structure**
The conversion process follows these steps:
1. **Validate Input** – Ensure the string is non-empty and formatted correctly.
2. **Check Repetition Validity** – Prevents incorrect character repetitions.
3. **Extract Arabic Values** – Converts each Roman numeral character into its respective Arabic value.
4. **Validate Subtractions** – Ensures that subtraction rules are followed.
5. **Calculate Total** – Converts the Roman numeral into an Arabic numeral.

The module uses a `Result<T>` pattern to ensure type safety and provide meaningful error handling, ensuring correct input processing.

Additionally, **unit tests** are implemented to validate all aspects of the conversion process. The test suite includes:
- **Valid numeral tests** to confirm correct conversions.
- **Invalid numeral tests** to ensure errors are properly handled.

---

## **Instructions to Run**
1. Clone the repository or download the source files.
2. Open the project in **Visual Studio** or any C# compatible IDE.
3. Build the project to ensure all dependencies are installed.
4. Run the console application:
   ```sh
   dotnet run
   ```
5. Enter a Roman numeral to convert, or type "exit" to quit.
6. Run tests using:
   ```sh
   dotnet test
   ```

---

## License

This project is open-source and available under the MIT License.
