import styles from "./CreateRecipeDisplay.module.css";

const CreateRecipeDisplay = (props) => {
  return (
    <div className={styles.RecipeDiv}>
      <div className={styles.CreateRecipeDisplay}>{props.children}</div>
    </div>
  );
};

export default CreateRecipeDisplay;
