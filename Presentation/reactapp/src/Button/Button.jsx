import React from "react";
import styles from "./Button.module.css";

const Button = (props) => {
  return (
    <div className={styles.ButtonDiv}>
      <button
        className={styles.ConfirmButton}
        type={props.type || "button"}
        onClick={props.onClick}
      >
        {props.children}
      </button>
    </div>
  );
};

export default Button;
