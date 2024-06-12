export default function TabButton({children, onClick, isClicked}) {
    return (
        <li>
            <button className={isClicked ? 'active' : undefined} onClick={onClick}>{children}</button>
        </li>
    );
}