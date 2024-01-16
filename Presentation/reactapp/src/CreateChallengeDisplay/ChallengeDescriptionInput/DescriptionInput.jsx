import React, { useState } from "react";
import styles from "./DescriptionInput.module.css";

const DescriptionInput = (props) => {
  const [descriptionValue, setDescriptionValue] = useState("");

  const handleDescriptionChange = (event) => {
    //update discreptionValue if there is a change
    const newValue = event.target.value;
    setDescriptionValue(newValue);

    if (props.onChange) {
      props.onChange(newValue);
    }
  };

  return (
    <div className={styles.DescriptionInputDiv}>
      <form className={styles.Form}>
        <label className={styles.Label} htmlFor="DescriptionInput">
          Beschrijving:
        </label>
        <textarea
          id="DescriptionInput"
          className={styles.DescriptionInput}
          type="text"
          name="Description"
          value={descriptionValue}
          onChange={handleDescriptionChange}
        />
      </form>
    </div>
  );
};

export default DescriptionInput;
