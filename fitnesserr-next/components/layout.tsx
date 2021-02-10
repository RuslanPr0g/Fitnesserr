import Head from "next/head";
import styles from "./layout.module.css";
import utilStyles from "../styles/utils.module.css";
import Link from "next/link";
import { LayoutProps } from "./LayoutProps";
import { Button } from '@material-ui/core';

const name = "Fitnesserr, to make life more fitnesser.";
export const siteTitle = "Fitnesserr";

export default function Layout({ children, home } : LayoutProps) {
  return (
    <div className={styles.container}>
      <Head>
        <link rel="icon" href="/favicon.ico" />
        <meta
          name="description"
          content="Learn how to build a personal website using Next.js"
        />
        <meta
          property="og:image"
          content={`https://og-image.now.sh/${encodeURI(
            siteTitle
          )}.png?theme=light&md=0&fontSize=75px&images=https%3A%2F%2Fassets.vercel.com%2Fimage%2Fupload%2Ffront%2Fassets%2Fdesign%2Fnextjs-black-logo.svg`}
        />
        <meta name="og:title" content={siteTitle} />
        <meta name="twitter:card" content="summary_large_image" />
      </Head>
      <header className={styles.header}>
        {home ? (
          <>
            <span className={`${styles.headerHomeImage}`}>{name}</span>
          </>
        ) : (
          <></>
        )}
      </header>
      <main className="main-content">{children}</main>
      {home && (
        <div className={styles.backToHome}>
          <Link href="/">
            <Button color="secondary" size={"large"}>← Back to home</Button>
          </Link>
        </div>
      )}
    </div>
  );
}
