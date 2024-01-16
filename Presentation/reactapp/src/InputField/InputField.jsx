import React, { useState } from "react";
import styles from "./InputField.module.css";
import "../fonts.css";

const Input = (props) => {
  const [textareaValue, setTextareaValue] = useState("");

  const handleTextareaChange = (event) => {
    const newValue = event.target.value;
    setTextareaValue(newValue);

    if (props.onChange) {
      props.onChange(newValue);
    }
  };

  return (
    <div className={styles.InputDiv}>
      <form className={styles.Form}>
        <label className={styles.Label} htmlFor={`${props.name}Input`}>
          {props.children}:
        </label>
        <textarea
          id={`${props.name}Input`}
          className={styles.Input}
          type="text"
          name={props.name}
          value={textareaValue}
          onChange={handleTextareaChange}
        />
      </form>
    </div>
  );
};

export default Input;
