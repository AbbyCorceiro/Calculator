# Calculator
## Description
  <p align="center">A simple WPF Calculator Application made in Visual Studio with the graphic interface made in XAML code</p>
  <p align="center">
    <img src= "https://github.com/user-attachments/assets/4cec0a5b-6a78-459d-b968-dce052dc55cf" alt = "Calculator Interface" width = "200"/>
  </p>

## Available Operations
  <ul>
    <li>Addition</li>
    <li>Substraction</li>
    <li>Division</li>
    <li>Multiplication</li>
    <li>Percentage</li>
  </ul>

## Documentation:
<h5>About the calculator</h5>
<ul>
  <li>
    <p>This calculator only operates with two numbers max. If you try to add a third one in the operation, it will only operate with the last two numbers. It's just a basic calculator</p>
  </li>
  <li>
    <p>The calculator operates with positive and negative numbers</p>
  </li>
  <li>
    <p>The variable type for the numbers is double. I made that choice because double offers better performance than decimal, and is often sufficient for general mathematical operations. Also it allows the user to operate with decimal numbers unlike "long" or "int" variable types</p>
  </li>
  <li>
    <p>In the click event for the decimal point button, there's an if with three different conditions. The first one checks if the text is not null, the second one makes sure that the text do not contain a decimal point already and the third one checks if the text itself ends with a decimal point, so the calculator will not allow the user to add another decimal point in the same number value</p>
  </li>
</ul>

## What's Next:
<h5>Next to do: </h5>
<ul>
    <li> - [x] Add basic operations</li>
    <li>
      - [x] Fix division by 0
      <ul>
        <li>The second number value will be the same to the first one in case the second number equals 0. This was made in this way beacause otherwise the result will be infinite, wich is mathematically imposible</li>
      </ul>
    </li>
    <li> - [ ] Handle exceptions</li>
    <li>
      - [ ] Make the remaining buttons work
      <ul>
        <li>- [x] Added percentage button</li>
        <li>- [x] Added decimal point button</li>
      </ul>
    </li>
</ul>

## Currently NOT Working:
<ul>
  <li>Button: C</li>
  <li>Button: CE</li>
  <li>Button: DEL</li>
</ul>

