import styles from "./ChallengeImage.Module.css";

const ChallengeImage = ({ recipe }) => {
  const imgurl = recipe.photos[0];
  return (
    <div className={styles.ChallengeImage}>
      <img src={imgurl} className={styles.Image}></img>
    </div>
  );
};

export default ChallengeImage;
