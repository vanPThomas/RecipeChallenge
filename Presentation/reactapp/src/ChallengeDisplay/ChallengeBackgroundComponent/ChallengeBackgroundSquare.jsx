import styles from "./ChallengeBackgroundSquare.module.css";
import ChallengeImage from "../ChallengeImageComponent/ChallengeImage";
import ChallengeBuyIcon from "../ChallengeBuyIconComponent/ChallengeBuyIcon";
import ChallengeTextBox from "../ChallengeTextBoxComponent/ChallengeTextBox";

const ChallengeBackgroundSquare = (props) => {
  const { recipe } = props;
  return (
    <div className={styles.ChallengeBackgroundSquare}>
      <ChallengeImage recipe={recipe} />
      <ChallengeBuyIcon />
      <ChallengeTextBox recipe={recipe} />
    </div>
  );
};

export default ChallengeBackgroundSquare;
