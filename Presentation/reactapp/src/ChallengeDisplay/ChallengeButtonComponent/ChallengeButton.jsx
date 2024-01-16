import React from "react";
import styles from "./ChallengeButton.module.css";
import { Link } from "react-router-dom";

const ChallengeButton = ({ challenge }) => {
  return (
    <Link to={`/recipe?challengeId=${challenge.id}`}>
      <button className={styles.ChallengeButton}>Ik doe mee !</button>
    </Link>
  );
};

export default ChallengeButton;
