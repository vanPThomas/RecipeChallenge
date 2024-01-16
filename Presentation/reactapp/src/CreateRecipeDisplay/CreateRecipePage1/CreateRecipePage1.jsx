import styles from "./CreateRecipePage1.module.css";
import Button from "../../Button/Button";
import InputField from "../../InputField/InputField";
import { Link, useLocation } from "react-router-dom";
import CreateRecipeDisplay from "../CreateRecipeDisplay";
import React, { useState } from "react";

const CreateRecipePage1 = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");

  const { search } = useLocation();
  const params = new URLSearchParams(search);
  const challengeId = params.get("challengeId");

  return (
    <CreateRecipeDisplay>
      <div className={styles.Headers}>
        <h2>Stap 1</h2>
        <h3>Voeg uw naam & e-mail toe</h3>
      </div>
      <InputField name="name" onChange={setName}>
        Naam
      </InputField>
      <div className={styles.Spacer}></div>
      <InputField name="email" onChange={setEmail}>
        E-mail
      </InputField>
      <Link
        to={`/recipe/2?name=${name}&email=${email}&challengeId=${challengeId}`}
      >
        <Button>Volgende</Button>
      </Link>
    </CreateRecipeDisplay>
  );
};

export default CreateRecipePage1;
