import Rectangle from "../Resource_images/Rectangle_Main_Page.svg";
import ImageBorder from "../Resource_images/Image_border_circle_Main_Page.svg";
import CurrentChallengeImage from "../Resource_images/Cookie_Monster_cupcake.png";
import styles from "./Header.module.css";
import "../fonts.css";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <div className={styles.HeaderDiv}>
      <img src={Rectangle} className={styles.RectangleMainPage} />
      <div className={styles.HeaderText}>
        <h4>Challenge van deze maand</h4>
        <h1>Wie maakt de grappigste cupcakes ever?</h1>
        <Link to="/recipe">
          <button>Doe mee!</button>
        </Link>
      </div>
      <div className={styles.ChallengeImageAndBorderContainer}>
        <img src={ImageBorder} className={styles.ImageBorderMainPage} />
        <div className={styles.ChallengeImageContainer}>
          <img
            src={CurrentChallengeImage}
            className={styles.CurrentChallengeImage}
          />
        </div>
      </div>
    </div>
  );
};

export default Header;
