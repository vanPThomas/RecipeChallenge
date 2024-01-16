import styles from "./ChallengeDescription.module.css";
import "../../fonts.css";

const ChallengeDescription = ({ challenge }) => {
  return (
    <>
      <h4 className={styles.h4}>{challenge.month}</h4>
      <p className={styles.p1}>{challenge.name} </p>
      <p className={styles.p2}>{challenge.description}</p>
    </>
  );
};

export default ChallengeDescription;
