import styles from './Card.module.css';

export default (props) => {
    return (
        <div className={styles.card}>{props.children}</div>
    )
}