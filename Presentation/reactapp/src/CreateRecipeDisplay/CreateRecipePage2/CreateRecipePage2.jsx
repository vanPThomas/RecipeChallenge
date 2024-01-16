import { useState } from "react";
import CreateRecipeDisplay from "../CreateRecipeDisplay";
import styles from "./CreateRecipePage2.module.css";
import InputField from "../../InputField/InputField";
import { Link, useLocation } from "react-router-dom";
import Button from "../../Button/Button";

const CreateRecipePage2 = () => {
  const { search } = useLocation();
  const params = new URLSearchParams(search);
  const name = params.get("name");
  const email = params.get("email");
  const challengeId = params.get("challengeId");

  const [title, setTitle] = useState("");

  return (
    <CreateRecipeDisplay>
      <div className={styles.Headers}>
        <h2>Stap 2</h2>
        <h3>Voeg een titel voor uw recept toe</h3>
      </div>
      <InputField name="title" onChange={setTitle}>
        Titel
      </InputField>
      <div className={styles.Spacer}></div>
      <Link
        to={`/recipe/3?name=${name}&email=${email}&title=${title}&challengeId=${challengeId}`}
      >
        <Button>Volgende</Button>
      </Link>
    </CreateRecipeDisplay>
  );
};

export default CreateRecipePage2;
