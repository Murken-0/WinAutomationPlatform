<template>
	<navigation-bar></navigation-bar>
	<div class="app">
		<router-view></router-view>
	</div>
</template>

<script>
import NavigationBar from "@/components/UI/NavigationBar.vue";

export default {
	components: {NavigationBar}

}
</script>

<style>
* {
	margin: 0;
	padding: 0;
	box-sizing: border-box;
}

.app {
	padding: 20px;
	width: 900px;
	margin: 0 auto;
}
</style>