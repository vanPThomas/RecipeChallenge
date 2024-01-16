import CreateRecipeDisplay from "../CreateRecipeDisplay";
import styles from "./CreateRecipePage5.module.css";
import { Link } from "react-router-dom";
import Button from "../../Button/Button";

const CreateRecipePage5 = () => {
  return (
    <CreateRecipeDisplay>
      <div className={styles.Headers}>
        <h1>Klaar!</h1>
        <h3>Uw recept is succesvol toegevoegd! Bedankt voor uw deelname.</h3>
      </div>
      <div className={styles.ImageUploader}></div>
      <Link to="/">
        <Button>Klaar</Button>
      </Link>
    </CreateRecipeDisplay>
  );
};

export default CreateRecipePage5;
