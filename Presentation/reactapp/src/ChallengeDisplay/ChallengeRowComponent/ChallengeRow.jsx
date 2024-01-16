import styles from "./ChallengeRow.module.css";
import ChallengeButton from "../ChallengeButtonComponent/ChallengeButton";
import ChallengeDescription from "../ChallengeDescriptionComponent/ChallengeDescription";
import ChallengeScrollLeft from "../ChallengeScrollComponent/ChallengeScrollLeft";
import ChallengeScrollRight from "../ChallengeScrollComponent/ChallengeScrollRight";
import { useRef, useState } from "react";

const ChallengeRow = (props) => {
  const ref = useRef(this);
  const { challenge, colour } = props;
  const [leftClick, setLeftClick] = useState(false);
  const [rightClick, setRightClick] = useState(false);

  const handleLeftClick = () => {
    setLeftClick(true);
    setTimeout(() => {
      setLeftClick(false);
    }, 500);
  };

  const handleRightClick = () => {
    setRightClick(true);
    setTimeout(() => {
      setRightClick(false);
    }, 500);
  };

  return (
    <>
      <div
        className={[
          styles.MainContainer,
          leftClick ? styles.LeftClick : "",
          rightClick ? styles.RightClick : "",
        ].join(" ")}
      >
        <div
          className={styles.ChallengeRow}
          style={{ backgroundColor: `${colour}, 0.15` }}
        >
          <div className={styles.ChallengeBackgroundInfo}>
            <div
              className={styles.Overlay}
              style={{ backgroundColor: `${colour}, 0.3` }}
            >
              <div className={styles.ChallengeDescriptionPosition}>
                <div className={styles.ChallengeButton}>
                  <ChallengeButton challenge={challenge} />
                </div>
                <div className={styles.ChallengeDescription}>
                  <ChallengeDescription challenge={challenge} />
                </div>
              </div>
            </div>
          </div>
          {props.children}
          <ChallengeScrollLeft onClick={handleLeftClick} />
          <ChallengeScrollRight onClick={handleRightClick} />
        </div>
      </div>
    </>
  );
};

export default ChallengeRow;
