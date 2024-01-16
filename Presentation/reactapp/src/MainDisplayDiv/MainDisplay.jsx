import React from "react";
import styles from "./MainDisplay.module.css";

const MainDisplay = (props) => {
  return (
    <>
      <div className={styles.MainDisplay}>{props.children}</div>
    </>
  );
};

export default MainDisplay;
