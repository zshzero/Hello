import { Link } from "react-router-dom"
import styles from "./MainNavigation.module.css"

export default () => {
    return (
        <header className={styles.header}>
            <div className={styles.logo}>Meetups</div>
            <nav>
                <ul>
                    <li>
                        <Link to="/">List AllMeetups</Link>
                    </li>
                    <li>
                        <Link to="/new">Add NewMeetup</Link>
                    </li>
                    <li>
                        <Link to="/fav">My Favorites</Link>
                    </li>
                </ul>
            </nav>
        </header>
    )
}