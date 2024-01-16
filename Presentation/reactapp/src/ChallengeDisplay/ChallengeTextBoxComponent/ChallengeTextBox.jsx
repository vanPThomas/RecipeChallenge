import React from "react";
import styles from "./ChallengeTextBox.module.css";
import "../../fonts.css";

const ChallengeTextBox = ({ recipe }) => {
  return <div className={styles.ChallengeTextBox}>{recipe.title}</div>;
};

export default ChallengeTextBox;
