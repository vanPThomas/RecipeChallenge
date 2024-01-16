import CollectGoLogo from "../Resource_images/Collect_Go_Prize_Icon.svg";
import CartIcon from "../Resource_images/Cart_Icon.svg";
import HeartIcon from "../Resource_images/Heart_Icon.svg";
import PersonIcon from "../Resource_images/Person_Icon.svg";
import SearchIcon from "../Resource_images/Search_Icon.svg";
import styles from "./Navbar.module.css";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className={styles.navbar}>
      <div className={styles.navbarLeft}>
        <Link to="/">
          <img className={styles.CollectGoLogo} src={CollectGoLogo} />
        </Link>
        <div>
          <Link className={styles.navbarHyperLinks} to="/">
            Klant
          </Link>
          <Link className={styles.navbarHyperLinks} to="/jury">
            Jury
          </Link>
          <Link className={styles.navbarHyperLinks} to="/beheer">
            Beheerder
          </Link>
        </div>
      </div>
      <div className={styles.navbarRight}>
        <div className={styles.searchbar}>
          <input
            className={styles.searchInputField}
            placeholder="Vind je recept of product"
          />
          <button className={styles.searchIconButton}>
            <img className={styles.searchicon} src={SearchIcon} />
          </button>
        </div>
        <div className={styles.iconsRight}>
          <Link>
            <img className={styles.icon} src={PersonIcon} />
          </Link>
          <Link>
            <img className={styles.icon} src={HeartIcon} />
          </Link>
          <Link>
            <img className={styles.icon} src={CartIcon} />
          </Link>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
